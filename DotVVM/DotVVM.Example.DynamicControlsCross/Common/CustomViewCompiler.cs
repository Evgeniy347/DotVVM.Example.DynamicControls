using System;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Compilation.Validation;
using Microsoft.Extensions.Options; 

namespace WSSC.V4.SYS.DotVVMReference
{
    /// <summary>
    /// Кастомный обработчик компиляции, для добавления в текст ошибки дополнительной информации
    /// </summary>
    //public class CustomViewCompiler : DefaultViewCompiler
    //{
        //        public override (ControlBuilderDescriptor, Func<IControlBuilder>) CompileView(string sourceCode, string fileName, string assemblyName, string namespaceName, string className)
        //        {
        //            return base.CompileView(sourceCode, fileName, assemblyName, namespaceName, className);
        //        }

        //        public override (ControlBuilderDescriptor, Func<CSharpCompilation>) CompileView(string sourceCode, string fileName, CSharpCompilation compilation, string namespaceName, string className)
        //        {
        //            var result = base.CompileView(sourceCode, fileName, compilation, namespaceName, className);

        //            Func<CSharpCompilation> func = result.Item2;
        //            result.Item2 = () =>
        //            {
        //                try
        //                {
        //                    return func();
        //                }
        //                catch (Exception ex)
        //                {
        //                    throw new Exception($@"
        //className:{className}
        //fileName:{fileName}
        //namespaceName:{namespaceName}
        //{new string('*', 50)}sourceCode{new string('*', 50)}
        //{sourceCode}
        //{new string('*', 50)}sourceCode{new string('*', 50)}
        //", ex);
        //                }
        //            }; 
        //            return result; 
        //        }
        //public CustomViewCompiler(IOptions<ViewCompilerConfiguration> config, IControlTreeResolver controlTreeResolver, IBindingCompiler bindingCompiler, Func<ControlUsageValidationVisitor> controlValidatorFactory, CompiledAssemblyCache compiledAssemblyCache) : base(config, controlTreeResolver, bindingCompiler, controlValidatorFactory, compiledAssemblyCache)
        //{
        //}
    //}
}