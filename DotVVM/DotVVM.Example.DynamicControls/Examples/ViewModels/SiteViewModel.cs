using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;

namespace DotVVM.Example.DynamicControls.Examples.ViewModels
{
    public class SiteViewModel : DotvvmViewModelBase
    {
        public override Task Init()
        {
            string path = "/Examples/UI.css";
            this.Context.ResourceManager.AddRequiredStylesheetFile(path, path);
            return base.Init();
        }

        public void PreviousPage() =>
            ChangeExample(false);

        public void NextPage() =>
            ChangeExample(true);

        public string NextPageRouteName => $"Next ({GetExample(true).Replace("Examples/", "")})";

        public string PreviousPageRouteName => $"Previous ({GetExample(false).Replace("Examples/", "")})";


        private void ChangeExample(bool isNext)
        {
            string nextRouteName = GetExample(isNext); 
            try
            { 
                this.Context.RedirectToRoute(nextRouteName);
            }
            catch (DotvvmInterruptRequestExecutionException)
            {
                throw; 
            }
        }


        private string GetExample(bool isNext)
        {
            List<string> routeNames = this.Context
                            .Configuration
                            .RouteTable
                            .Select(x => x.RouteName)
                            .Where(x => x.Contains("Examples/") && x!= "Examples/Defaulte")
                            .ToList();

            string currentName = this.Context.Route.RouteName;
            int currentIndex = routeNames.IndexOf(currentName);
            int nextIndex = 0;
            if (currentIndex != -1)
            {
                nextIndex = isNext ? currentIndex + 1 : currentIndex - 1;

                if (nextIndex < 0)
                    nextIndex = routeNames.Count - 1;
                else if (nextIndex >= routeNames.Count)
                    nextIndex = 0;
            }

            string nextRouteName = routeNames[nextIndex];
            return nextRouteName;
        }
    }
}

