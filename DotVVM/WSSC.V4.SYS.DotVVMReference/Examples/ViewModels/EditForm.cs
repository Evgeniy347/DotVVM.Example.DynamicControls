using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Utils;
using DotVVM.Framework.ViewModel;
using WSSC.V4.SYS.DotVVMReference.Examples.Controls;
using DotVVM.Framework.Compilation.ControlTree;
using Newtonsoft.Json.Linq;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Compilation.Javascript.Ast;
using WSSC.V4.SYS.DotVVMReference.Extensions;
using Newtonsoft.Json;
using System.Xml.Linq;
using WSSC.V4.SYS.DotVVMReference.Examples.Model;

namespace WSSC.V4.SYS.DotVVMReference.Examples.ViewModels
{
    public class EditForm : SiteViewModel
    {
        public bool Value { get; set; } = true;

        private readonly BindingCompilationService _bindingCompilationService;

        //public List<FieldValue> Fields { get; set; } = new List<FieldValue>();

        public EditForm(BindingCompilationService bindingCompilationService)
        {
            _bindingCompilationService = bindingCompilationService;
        }

        [FromRoute("ListName")]
        public string ListName { get; set; }

        [FromRoute("ID")]
        public int ID { get; set; }

        public string LiteralText { get; set; }
        public string TextValue { get; set; }

        public FileItem Item { get; set; }

        public string HtmlServer { get; set; }

        public override Task Init()
        {
            return base.Init().ContinueWith(x =>
               {
                   FileSite site = DocumentAdapter.EnshureSite();
                   FileList list = site.Lists[ListName];
                   FileItem item = list.Items[ID];
                   Item = item;

                   //DotvvmControl control = this.Context
                   //    .View
                   //    .GetAllDescendants()
                   //    .FirstOrDefault(x => x is PlaceHolder && x.ClientID == "DinamicControls");
               });
        }

        public void Click()
        {
            Item.FieldValue[4].Value = !((bool)Item.FieldValue[4].Value);
        }
    }
}

