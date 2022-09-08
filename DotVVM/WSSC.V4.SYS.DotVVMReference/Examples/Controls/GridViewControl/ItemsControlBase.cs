#region сборка DotVVM.BusinessPack, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f
// C:\Users\GTR\Desktop\По работе\DotVVM\packages\DotVVM.BusinessPack.4.0.5-trial\lib\net472\DotVVM.BusinessPack.dll
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Binding.Properties;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Compilation.ControlTree.Resolved;
using DotVVM.Framework.Compilation.Styles;
using DotVVM.Framework.Controls;

namespace WSSC.V4.SYS.DotVVMReference.Controls
{
    //
    // Сводка:
    //     The base class for BusinessPack controls operating on a collection. It registers
    //     BusinessPack resources in OnInit phase.
    //
    // Параметры типа:
    //   TDataSource:
    //     The type of data source.
    public abstract class ItemsControlBase<TDataSource> : HtmlControlBase where TDataSource : class
    {
        public static readonly DotvvmProperty DataSourceProperty = DotvvmProperty.Register<TDataSource, ItemsControlBase<TDataSource>>((ItemsControlBase<TDataSource> t) => t.DataSource);

        //
        // Сводка:
        //     Gets or sets the data source containing data for this control.
        [BindingCompilationRequirements(new Type[] { typeof(DataSourceAccessBinding) }, new Type[] { typeof(DataSourceLengthBinding) }, null)]
        [MarkupOptions(AllowHardCodedValue = false)]
        public virtual TDataSource DataSource
        {
            get
            {
                return (TDataSource)GetValue(DataSourceProperty);
            }
            set
            {
                SetValue(DataSourceProperty, value);
            }
        }

        //
        // Сводка:
        //     Gets whether the data source is empty.
        protected virtual bool IsDataSourceEmpty => !GetItems().Any();

        protected ItemsControlBase(BindingCompilationService bindingService)
            : base(bindingService)
        {
        }

        protected ItemsControlBase(string tagName, BindingCompilationService bindingService)
            : base(tagName, bindingService)
        {
        }

        //
        // Сводка:
        //     Returns an enumerable from the data source. It supports System.Collections.IEnumerable
        //     and DotVVM.Framework.Controls.IBaseGridViewDataSet data sources.
        public IEnumerable<object> GetItems()
        {
            return (GetItemsAccessBinding().Evaluate(this) as IEnumerable)?.Cast<object>() ?? Enumerable.Empty<object>();
        }

        //
        // Сводка:
        //     Returns a binding used to access items in the DotVVM.BusinessPack.Controls.ItemsControlBase`1.DataSource.
        protected IValueBinding GetItemsAccessBinding()
        {
            return (IValueBinding)GetDataSourceBinding().GetProperty<DataSourceAccessBinding>().Binding;
        }

        //
        // Сводка:
        //     Returns a binding used to check whether the DotVVM.BusinessPack.Controls.ItemsControlBase`1.DataSource
        //     is empty.
        protected virtual IValueBinding GetIsDataSourceEmptyBinding()
        {
            return (IValueBinding)GetIsDataSourceNotEmptyBinding().GetProperty<NegatedBindingExpression>().Binding;
        }

        //
        // Сводка:
        //     Returns a binding used to check whether the DotVVM.BusinessPack.Controls.ItemsControlBase`1.DataSource
        //     is not empty.
        protected virtual IValueBinding GetIsDataSourceNotEmptyBinding()
        {
            return (IValueBinding)GetDataSourceBinding().GetProperty<DataSourceLengthBinding>().Binding.GetProperty<IsMoreThanZeroBindingProperty>()
                .Binding;
        }

        //
        // Сводка:
        //     Returns a binding used to retrieve an item from the DotVVM.BusinessPack.Controls.ItemsControlBase`1.DataSource.
        protected IValueBinding GetItemAccessBinding()
        {
            return (IValueBinding)GetItemsAccessBinding().GetProperty<DataSourceCurrentElementBinding>().Binding;
        }

        //
        // Сводка:
        //     Returns an expression used to identify commands executed on child controls.
        protected string GetPathFragmentExpression()
        {
            return GetDataSourceBinding().GetKnockoutBindingExpression(this);
        }

        //
        // Сводка:
        //     Returns a value binding from the DotVVM.BusinessPack.Controls.ItemsControlBase`1.DataSource
        //     property or throws an exception when the property is not set.
        protected IValueBinding GetDataSourceBinding()
        {
            return GetValueBinding(DataSourceProperty) ?? throw new DotvvmControlException(this, "The DataSource property of the '" + GetType().Name + "' control must be set!");
        }

        [ApplyControlStyle]
        public static void OnCompilation(ResolvedControl control, BindingCompilationService bindingService)
        {
            if (control.HasProperty(DataSourceProperty))
            {
                (ITypeDescriptor? type, List<BindingExtensionParameter> extensionParameters) tuple = ControlTreeResolverBase.ApplyContextChange(control.DataContextTypeStack, new DataContextChangeAttribute[2]
                {
                    new ControlPropertyBindingDataContextChangeAttribute("DataSource"),
                    new CollectionElementDataContextChangeAttribute(0)
                }, control, null);
                ITypeDescriptor item = tuple.type;
                List<BindingExtensionParameter> item2 = tuple.extensionParameters;
                DataContextStack dataContextStack = DataContextStack.Create(ResolvedTypeDescriptor.ToSystemType(item), control.DataContextTypeStack, null, item2);

                throw new NotImplementedException();

                //control.SetProperty(new ResolvedPropertyBinding(Internal.CurrentIndexBindingProperty, 
                //    new ResolvedBinding(bindingService, 
                //    new BindingParserOptions(typeof(ValueBindingExpression), 
                //    "_this", 
                //    (ImmutableArray<NamespaceImport>?)null, 
                //    (ImmutableArray<BindingExtensionParameter>?)null), 
                //    dataContextStack,
                //    null,
                //    Expression.Parameter(typeof(int), "_index")
                //    .AddParameterAnnotation(
                //        new BindingParameterAnnotation(dataContextStack, 
                //    new CurrentCollectionIndexExtensionParameter())))));
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
