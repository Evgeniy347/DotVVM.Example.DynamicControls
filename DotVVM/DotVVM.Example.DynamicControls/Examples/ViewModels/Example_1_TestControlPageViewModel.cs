using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using DotVVM.Example.DynamicControls.Examples.Controls;

namespace DotVVM.Example.DynamicControls.Examples.ViewModels
{
    public class Example_1_TestControlPageViewModel : SiteViewModel
    {
        public string LiteralText { get; set; }

        public string TextValue { get; set; }

        public override Task Init()
        { 
            //PlaceHolder contentPlaceHolder = (PlaceHolder)this.Context.View.FindControlByClientId("customControl");

            //DotVVM.BusinessPack.Controls.ItemsControlBase
            //DotVVM.BusinessPack.Controls.GridView
            Literal literal = new Literal();
            literal.Text = "asdsadasd";

            this.Context.View.Children.Add(literal);
            //contentPlaceHolder.Children.Add(literal);

            return base.Init();
        }

        public void Click()
        {
            LiteralText = TextValue;
        }
    }
}

