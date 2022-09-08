using DotVVM.Framework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSSC.V4.SYS.DotVVMReference.Examples.ViewModels;

namespace WSSC.V4.SYS.DotVVMReference.Examples.Controls
{ 
    public class FieldsValue  
    {
        public FieldValue[] FieldValue { get; set; }
    }

    public class FieldValue
    {
        public object Value { get; set; }
        public string Name { get; set; }
        public FieldSetting FieldSetting { get; set; }
    }

    public class FileSite
    {
        public Dictionary<string, FileList> Lists { get; set; }
    }

    public class FileList
    {
        public string Name { get; set; }

        public FieldSetting[] Fields { get; set; }

        public Dictionary<int, FileItem> Items { get; set; }
    }

    public class FieldSetting
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class FileItem
    {
        public int ID { get; set; } 
        public FieldValue[] FieldValue { get; set; }
    }
}
