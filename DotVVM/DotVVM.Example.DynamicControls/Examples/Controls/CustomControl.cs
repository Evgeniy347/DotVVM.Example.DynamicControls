using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace DotVVM.Example.DynamicControls.Examples.Controls
{
    public class CustomControl : DotvvmMarkupControl
    {
        protected override void OnInit(IDotvvmRequestContext context)
        {
            base.OnInit(context); 
            context.ResourceManager.AddStartupScript("console.log('test AddStartupScript');");
        }
    } 
}

