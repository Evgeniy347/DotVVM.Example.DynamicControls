#region сборка DotVVM.BusinessPack.Core, Version=4.0.5.0, Culture=neutral, PublicKeyToken=77e8efd43b7ae75f
// C:\Users\GTR\Desktop\По работе\DotVVM\packages\DotVVM.BusinessPack.Core.4.0.5-trial\lib\net472\DotVVM.BusinessPack.Core.dll
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using DotVVM.Framework.Controls;

namespace WSSC.V4.SYS.DotVVMReference.Controls
{
    //
    // Сводка:
    //     Represents a collection of items with filtering, paging, sorting, row edit and
    //     row insert capabilities.
    public interface IBusinessPackDataSet : IGridViewDataSet, IPageableGridViewDataSet, IBaseGridViewDataSet, ISortableGridViewDataSet, IRowEditGridViewDataSet, IRefreshableGridViewDataSet, IRowInsertGridViewDataSet, IFilterableDataSet
    {
    }
}
#if false // Журнал декомпиляции
Элементов в кэше: "148"
------------------
Разрешить: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\mscorlib.dll"
------------------
Разрешить: "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.dll"
------------------
Разрешить: "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Core.dll"
------------------
Разрешить: "DotVVM.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Найдена одна сборка: "DotVVM.Framework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Внимание! Несовпадение версий. Ожидалось: "4.0.0.0", получено: "3.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\DotVVM.Framework.dll"
------------------
Разрешить: "Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed"
Найдена одна сборка: "Newtonsoft.Json, Version=11.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed"
Внимание! Несовпадение версий. Ожидалось: "10.0.0.0", получено: "11.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\Newtonsoft.Json.dll"
------------------
Разрешить: "DotVVM.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Найдена одна сборка: "DotVVM.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=23f3607db32275da"
Внимание! Несовпадение версий. Ожидалось: "4.0.0.0", получено: "3.0.0.0"
Загрузить из: "C:\Users\GTR\Desktop\По работе\DotVVM\WSSC.V4.SYS.DotVVMReference\Refs\DotVVM.Core.dll"
------------------
Разрешить: "System.ComponentModel.DataAnnotations, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Найдена одна сборка: "System.ComponentModel.DataAnnotations, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.ComponentModel.DataAnnotations.dll"
------------------
Разрешить: "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
Не удалось найти по имени: "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
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
Разрешить: "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Xml.dll"
------------------
Разрешить: "System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Найдена одна сборка: "System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Загрузить из: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\System.Xml.Linq.dll"
------------------
Разрешить: "System.Web.ApplicationServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
Не удалось найти по имени: "System.Web.ApplicationServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
#endif
