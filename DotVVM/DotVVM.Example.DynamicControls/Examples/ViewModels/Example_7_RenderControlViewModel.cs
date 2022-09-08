using System; 
using DotVVM.Framework.Controls; 
using DotVVM.Example.DynamicControls.Extensions; 

namespace DotVVM.Example.DynamicControls.Examples.ViewModels
{
    public class Example_7_RenderControlViewModel : SiteViewModel
    {
        public Example_7_RenderControlViewModel()
        {
        }

        public string HtmlServer
        {
            get
            {
                Literal literal = new Literal();
                literal.Text = "TestValue"; 
                string result = literal.RenderControlToHtml();
                return result;
                //return "<p>TestValue<p>";
            }
        } 
    }
}

