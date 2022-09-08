using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace WSSC.V4.SYS.DotVVMReference.Examples.ViewModels
{
    public class Example_1_TestControlPageViewModel : SiteViewModel
    {
        public string LiteralText { get; set; }
        
        public string TextValue { get; set; }

        public void Click()
        {
            LiteralText = TextValue;
        }
    }
}

