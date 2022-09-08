using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotVVM.Example.DynamicControls.Examples.ViewModels
{
    public class Example_2_TwoButtonsViewModel : SiteViewModel
    { 
        public string LiteralText { get; set; }

        public string TextValue1 { get; set; }

        public string TextValue2 { get; set; }

        public void Click1()
        {
            LiteralText = TextValue1;
        }
        public void Click2()
        {
            LiteralText = TextValue2;
        }
    }
}

