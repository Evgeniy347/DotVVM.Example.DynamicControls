using System; 
using DotVVM.Framework.Controls; 
using WSSC.V4.SYS.DotVVMReference.Extensions; 

namespace WSSC.V4.SYS.DotVVMReference.Examples.ViewModels
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

