using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Compilation.Parser.Binding.Parser;
using DotVVM.Framework.Compilation.Parser.Dothtml.Parser;
using DotVVM.Framework.Compilation.Parser.Binding.Tokenizer;
using System.Diagnostics;
using System.Text;
using DotVVM.Framework.ResourceManagement; 

namespace WSSC.V4.SYS.DotVVMReference
{
    /// <summary>
    /// Доработано получение полного имени сборки
    /// </summary>
    public class CustomControlTreeResolver : DefaultControlTreeResolver, IControlTreeResolver
    {
        public CustomControlTreeResolver(IControlResolver controlResolver, IControlBuilderFactory controlBuilderFactory, IAbstractTreeBuilder treeBuilder) : base(controlResolver, controlBuilderFactory, treeBuilder)
        {
        }

        protected override BindingParserNode ParseDirectiveTypeName(
            DothtmlDirectiveNode directiveNode)
        { 
            BindingTokenizer bindingTokenizer = new BindingTokenizer();
            bindingTokenizer.Tokenize(directiveNode.ValueNode.Text);
            BindingParser bindingParser1 = new BindingParser();
            bindingParser1.Tokens = bindingTokenizer.Tokens;
            BindingParser bindingParser2 = bindingParser1;
            BindingParserNode directiveTypeName = bindingParser2.ReadDirectiveTypeName();
            if (bindingParser2.OnEnd())
                return directiveTypeName;

            if (directiveTypeName is AssemblyQualifiedNameBindingParserNode assembleNode)
            {
                StringBuilder assemblyName = new StringBuilder();
                assemblyName.Append(assembleNode.AssemblyName.ToDisplayString());

                while (!bindingParser2.OnEnd())
                {
                    var token = bindingParser2.Read();
                    assemblyName.Append(token.Text);
                }

                SimpleNameBindingParserNode assembleNameNode = new SimpleNameBindingParserNode(assemblyName.ToString());
                return new AssemblyQualifiedNameBindingParserNode(assembleNode.TypeName, assembleNameNode); 
            }

            directiveNode.AddError("Unexpected token: " + bindingParser2.Peek()?.Text + $". ''");
            return directiveTypeName;
        }
    }
}