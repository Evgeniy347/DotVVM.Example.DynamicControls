#region сборка DotVVM.BusinessPack, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f
// C:\Users\GTR\Desktop\По работе\DotVVM\packages\DotVVM.BusinessPack.4.0.5-trial\lib\net472\DotVVM.BusinessPack.dll
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using DotVVM.Utils.HtmlElements;

namespace WSSC.V4.SYS.DotVVMReference.Controls
{
    //
    // Сводка:
    //     The base class for BusinessPack controls. It registers BusinessPack resources
    //     in OnInit phase.
    public abstract class HtmlControlBase : HtmlGenericControl, IBusinessPackControl
    {
        private DotvvmProperty wrapperTagNameProperty;

        //
        // Сводка:
        //     Gets the name used to find the client-side control instance.
        public virtual string ControlName => GetType().Name;

        //
        // Сводка:
        //     Gets whether the control is initially visible. If the result is false the control
        //     is rendered with display: none; style.
        public virtual bool IsInitiallyVisible => base.Visible;

        //
        // Сводка:
        //     Gets the service required to create bindings.
        protected BindingCompilationService BindingService { get; }

        //
        // Сводка:
        //     Gets the factory used to build control's HTML structure.
        protected HtmlFactory HtmlFactory { get; } = new HtmlFactory();


        //
        // Сводка:
        //     Gets whether the control was initialized with only white space content.
        protected bool HadOnlyWhiteSpaceContentOnInit { get; private set; } = true;


        protected HtmlControlBase(BindingCompilationService bindingService)
        {
            BindingService = bindingService;
        }

        protected HtmlControlBase(string tagName, BindingCompilationService bindingService)
            : base(tagName)
        {
            BindingService = bindingService;
        }

        protected HtmlControlBase(DotvvmProperty wrapperTagNameProperty, BindingCompilationService bindingService)
        {
            this.wrapperTagNameProperty = wrapperTagNameProperty;
            BindingService = bindingService;
        }

        protected override void OnInit(IDotvvmRequestContext context)
        {
            context.ResourceManager.AddBusinessPackRequiredResources(context);
            HadOnlyWhiteSpaceContentOnInit = HasOnlyWhiteSpaceContent();
            base.OnInit(context);
        }

        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            if (base.DataContext != null)
            {
                ValidateUsageAtRuntime(context);
            }

            this.EnsureInvalidCssClass();
            base.OnPreRender(context);
        }

        //
        // Сводка:
        //     Validates the control and its properties in PreRender phase.
        //
        // Параметры:
        //   context:
        //     The DotVVM request context.
        protected virtual void ValidateUsageAtRuntime(IDotvvmRequestContext context)
        {
        }

        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            HtmlWriterExtensions.AddCssClass(writer, BusinessPackCss.Control);
            base.AddAttributesToRender(writer, context);
        }

        protected override void AddVisibleAttributeOrBinding(in RenderState r, IHtmlWriter writer)
        {
            object visible = r.Visible;
            IValueBinding valueBinding = visible as IValueBinding;
            if (valueBinding != null)
            {
                writer.AddKnockoutDataBind("visible", valueBinding.WrappedKnockoutExpression.FormatKnockoutScript(this, valueBinding));
            }

            if (base.DataContext != null && !IsInitiallyVisible)
            {
                HtmlWriterExtensions.AddCssClass(writer, BusinessPackCss.StateHidden);
            }
        }
    }
}
#if false // Журнал декомпиляции
Элементов в кэше: "148"
------------------
Разрешить: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\mscorlib.dll"
------------------
Разрешить: "DotVVM.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Найдена одна сборка: "DotVVM.Framework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Внимание! Несовпадение версий. Ожидалось: "4.0.0.0", получено: "3.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\DotVVM.Framework.dll"
------------------
Разрешить: "Microsoft.Extensions.DependencyInjection.Abstractions, Version=2.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Найдена одна сборка: "Microsoft.Extensions.DependencyInjection.Abstractions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Внимание! Несовпадение версий. Ожидалось: "2.0.0.0", получено: "1.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\Microsoft.Extensions.DependencyInjection.Abstractions.dll"
------------------
Разрешить: "Microsoft.Extensions.Options, Version=2.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Найдена одна сборка: "Microsoft.Extensions.Options, Version=1.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60"
Внимание! Несовпадение версий. Ожидалось: "2.0.0.0", получено: "1.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\Microsoft.Extensions.Options.dll"
------------------
Разрешить: "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.dll"
------------------
Разрешить: "DotVVM.Utils.HtmlElements, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f"
Не удалось найти по имени: "DotVVM.Utils.HtmlElements, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f"
------------------
Разрешить: "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Core.dll"
------------------
Разрешить: "DotVVM.BusinessPack.Core, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f"
Найдена одна сборка: "DotVVM.BusinessPack.Core, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\packages\DotVVM.BusinessPack.Core.4.0.5-trial\lib\net472\DotVVM.BusinessPack.Core.dll"
------------------
Разрешить: "System.Collections.Immutable, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Collections.Immutable, Version=1.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Внимание! Несовпадение версий. Ожидалось: "5.0.0.0", получено: "1.2.2.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\System.Collections.Immutable.dll"
------------------
Разрешить: "DotVVM.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Найдена одна сборка: "DotVVM.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Внимание! Несовпадение версий. Ожидалось: "4.0.0.0", получено: "3.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\DotVVM.Core.dll"
------------------
Разрешить: "System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Xml.Linq.dll"
------------------
Разрешить: "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Xml.dll"
------------------
Разрешить: "Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed"
Найдена одна сборка: "Newtonsoft.Json, Version=11.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed"
Внимание! Несовпадение версий. Ожидалось: "10.0.0.0", получено: "11.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\Newtonsoft.Json.dll"
------------------
Разрешить: "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Найдена одна сборка: "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Facades\netstandard.dll"
------------------
Разрешить: "System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Data.dll"
------------------
Разрешить: "System.Diagnostics.Tracing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Не удалось найти по имени: "System.Diagnostics.Tracing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
------------------
Разрешить: "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Не удалось найти по имени: "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
------------------
Разрешить: "System.IO.Compression, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.IO.Compression, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.IO.Compression.FileSystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.IO.Compression.FileSystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.ComponentModel.Composition, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.ComponentModel.Composition, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Не удалось найти по имени: "System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
------------------
Разрешить: "System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.Runtime.Serialization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.Runtime.Serialization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.Transactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Не удалось найти по имени: "System.Transactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
------------------
Разрешить: "System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Найдена одна сборка: "System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Web.dll"
------------------
Разрешить: "System.Web.ApplicationServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Не удалось найти по имени: "System.Web.ApplicationServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
#endif
