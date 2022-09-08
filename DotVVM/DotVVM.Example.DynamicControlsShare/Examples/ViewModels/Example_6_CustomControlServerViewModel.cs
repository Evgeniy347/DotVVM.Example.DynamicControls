using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using WSSC.V4.SYS.DotVVMReference.Examples.Controls;
using WSSC.V4.SYS.DotVVMReference.Examples.Data;
using WSSC.V4.SYS.DotVVMReference.Examples.Model;

namespace WSSC.V4.SYS.DotVVMReference.Examples.ViewModels
{
    public class Example_6_CustomControlServerViewModel : SiteViewModel
    { 
        public Example_6_CustomControlServerViewModel()
        { 
        }

        public override Task Init()
        { 
            string path = "_layouts/WSS/WSSC.V4.SYS.DotVVMReference/Examples/Resource/Example_6_CustomControlServerViewModel.js";
            this.Context.ResourceManager.AddRequiredScriptFile(path, path);
            this.Context.ResourceManager.AddStartupScript(" function testInvokeBlock(){ alert('testInvokeBlock'); }");
            return base.Init();
        }
    }
}

