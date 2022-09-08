using System;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Compilation;
using System.Reflection;
using System.Linq;
using DotVVM.Framework.Compilation.ControlTree.Resolved;
using DotVVM.Framework.Compilation.Binding;
using DotVVM.Framework.Compilation.Parser.Binding.Parser;
using DotVVM.Framework.Compilation.Parser.Dothtml.Parser;
using System.Linq.Expressions;

namespace WSSC.V4.SYS.DotVVMReference
{ 
    /// <summary>
    /// Кастомный обработчик для получения модели из сборок в GAC
    /// </summary>
    public class CustomResolvedTreeBuilder : ResolvedTreeBuilder, IAbstractTreeBuilder
    { 
        private readonly CompiledAssemblyCache compiledAssemblyCache;
        private readonly MemberExpressionFactory memberExpressionFactory;

        public CustomResolvedTreeBuilder(BindingCompilationService bindingService, CompiledAssemblyCache compiledAssemblyCache, ExtensionMethodsCache extensionsMethodsCache) : base(bindingService, compiledAssemblyCache, extensionsMethodsCache)
        {
        }

        public IAbstractViewModelDirective BuildViewModelDirective(
          DothtmlDirectiveNode directive,
          BindingParserNode nameSyntax)
        {
            ResolvedTypeDescriptor resolvedType = this.ResolveTypeNameDirective(directive, nameSyntax);
            ResolvedViewModelDirective viewModelDirective = new ResolvedViewModelDirective(nameSyntax, resolvedType);
            viewModelDirective.DothtmlNode = (DothtmlNode)directive;
            return (IAbstractViewModelDirective)viewModelDirective;
        }

        public IAbstractBaseTypeDirective BuildBaseTypeDirective(
          DothtmlDirectiveNode directive,
          BindingParserNode nameSyntax)
        {
            ResolvedTypeDescriptor resolvedType = this.ResolveTypeNameDirective(directive, nameSyntax);
            ResolvedBaseTypeDirective baseTypeDirective = new ResolvedBaseTypeDirective(nameSyntax, resolvedType);
            baseTypeDirective.DothtmlNode = (DothtmlNode)directive;
            return (IAbstractBaseTypeDirective)baseTypeDirective;
        }

        private ResolvedTypeDescriptor ResolveTypeNameDirective(
          DothtmlDirectiveNode directive,
          BindingParserNode nameSyntax)
        {
            if (this.ParseDirectiveExpression(directive, nameSyntax) is StaticClassIdentifierExpression directiveExpression)
                return new ResolvedTypeDescriptor(directiveExpression.Type);
            else if (nameSyntax is AssemblyQualifiedNameBindingParserNode assembleNode)
            {

                //Все кастомные сборки должны быть уже добавлены
                Assembly assembly = Assembly.Load(assembleNode.AssemblyName.ToDisplayString());
                if (assembly != null)
                {
                    Type type = assembly.GetType(assembleNode.TypeName.ToDisplayString());

                    if (type != null)
                        return new ResolvedTypeDescriptor(type);

                    directive.AddError("Could not resolve type from assembly '" + nameSyntax.ToDisplayString() + $"'. {nameSyntax.GetType()}");
                }

                directive.AddError("Could not resolve assembly '" + nameSyntax.ToDisplayString() + $"'. {nameSyntax.GetType()}");
            }
            else
            {
                directive.AddError("Could not resolve type '" + nameSyntax.ToDisplayString() + $"'. {nameSyntax.GetType()}");
            }
            return null;
        }

        private Expression ParseDirectiveExpression(
          DothtmlDirectiveNode directive,
          BindingParserNode expressionSyntax)
        {
            TypeRegistry registry;
            if (expressionSyntax is AssemblyQualifiedNameBindingParserNode bindingParserNode)
            {
                expressionSyntax = bindingParserNode.TypeName;
                registry = TypeRegistry.DirectivesDefault(this.compiledAssemblyCache, bindingParserNode.AssemblyName.ToDisplayString());
            }
            else
                registry = TypeRegistry.DirectivesDefault(this.compiledAssemblyCache);
            ExpressionBuildingVisitor expressionBuildingVisitor = new ExpressionBuildingVisitor(registry, this.memberExpressionFactory)
            {
                ResolveOnlyTypeName = true,
                Scope = (Expression)null
            };
            try
            {
                return expressionBuildingVisitor.Visit(expressionSyntax);
            }
            catch (Exception ex)
            {
                directive.AddError(expressionSyntax.ToDisplayString() + " is not a valid type or namespace: " + ex.Message);
                return (Expression)null;
            }
        }

    }
}