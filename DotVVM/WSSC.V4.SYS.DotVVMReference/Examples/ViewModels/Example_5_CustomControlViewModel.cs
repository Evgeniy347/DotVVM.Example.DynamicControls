using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using WSSC.V4.SYS.DotVVMReference.Examples.Controls;
using WSSC.V4.SYS.DotVVMReference.Examples.Data;
using WSSC.V4.SYS.DotVVMReference.Examples.Model;

namespace WSSC.V4.SYS.DotVVMReference.Examples.ViewModels
{
    public class Example_5_CustomControlViewModel : SiteViewModel
    {
        private readonly CustomControlModel _model = new CustomControlModel();
        public Example_5_CustomControlViewModel()
        {
            CustomControl1 = _model.GetUserData(1);
            CustomControl2 = _model.GetUserData(2);
        }

        public UserInfoData CustomControl1 { get; set; }

        public UserInfoData CustomControl2 { get; set; }

        public string LiteralText { get; set; }

        public void SaveValue()
        {
            _model.Save(CustomControl1);
            _model.Save(CustomControl2);
        }
    }
}

