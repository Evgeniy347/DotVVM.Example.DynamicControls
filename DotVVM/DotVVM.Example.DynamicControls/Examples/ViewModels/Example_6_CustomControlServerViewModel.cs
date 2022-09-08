using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Example.DynamicControls.Examples.Controls;
using DotVVM.Example.DynamicControls.Examples.Data;
using DotVVM.Example.DynamicControls.Examples.Model;

namespace DotVVM.Example.DynamicControls.Examples.ViewModels
{
    public class Example_6_CustomControlServerViewModel : SiteViewModel
    { 
        public Example_6_CustomControlServerViewModel()
        { 
        }

        public override Task Init()
        { 
            string path = "_layouts/WSS/DotVVM.Example.DynamicControls/Examples/Resource/Example_6_CustomControlServerViewModel.js";
            this.Context.ResourceManager.AddRequiredScriptFile(path, path);
            this.Context.ResourceManager.AddStartupScript(" function testInvokeBlock(){ alert('testInvokeBlock'); }");
            return base.Init();
        }
    }
}

