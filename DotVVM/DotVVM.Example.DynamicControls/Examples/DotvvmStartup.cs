using DotVVM.Framework.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Routing;
using DotVVM.Example.DynamicControls.Examples.ViewModels;
using System.IO;

namespace DotVVM.Example.DynamicControls.Examples
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            //if (Directory.Exists("C:\\Users\\GTR\\Desktop\\По работе\\DotVVM\\DotVVM.Example.DynamicControls"))
            //    config.ApplicationPhysicalPath = "C:\\Users\\GTR\\Desktop\\По работе\\DotVVM\\DotVVM.Example.DynamicControls";
            //else
            //    config.ApplicationPhysicalPath = "C:\\testapp\\www\\DotVVM.Example.DynamicControls"; 
            //"C:\Users\GTR\source\repos\DotVVM.Example.DynamicControls\DotVVM\Test\Examples\Controls".

            config.ApplicationPhysicalPath += "..\\DotVVM.Example.DynamicControls";


           config.ExperimentalFeatures.ExplicitAssemblyLoading.Enabled = true;
            config.Debug = true;
            config.AllowBindingDebugging = true;
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            //явно зарегистрировать  
            config.RouteTable.Add("Examples/TestControlPage", "Examples/TestControlPage", "Examples/Views/Example_1_TestControlPage.dothtml");
            config.RouteTable.Add("Examples/TwoButtons", "Examples/TwoButtons", "Examples/Views/Example_2_TwoButtons.dothtml");
            config.RouteTable.Add("Examples/ComboBox", "Examples/ComboBox", "Examples/Views/Example_3_ComboBox.dothtml");
            config.RouteTable.Add("Examples/CustomControl", "Examples/CustomControl", "Examples/Views/Example_5_CustomControl.dothtml");
            config.RouteTable.Add("Examples/CustomControlServer", "Examples/CustomControlServer", "Examples/Views/Example_6_CustomControlServer.dothtml");
            config.RouteTable.Add("Examples/RenderControl", "Examples/RenderControl", "Examples/Views/Example_7_RenderControl.dothtml");
            config.RouteTable.Add("Examples/DinamicGridView", "Examples/DinamicGridView", "Examples/Views/Example_7_DinamicGridView.dothtml");
            config.RouteTable.Add("OnlyDinamicGridView", "Examples/OnlyDinamicGridView", "Examples/Views/Example_7_OnlyDinamicGridView.dothtml");

            config.RouteTable.Add("Examples/Defaulte", "", "Examples/Views/Example_1_TestControlPage.dothtml");
            //config.RouteTable.AddRouteRedirection("Examples/Redirect", "", "Examples/Defaulte");
            config.RouteTable.Add("EditForm", "Examples/EditForm/{ListName}/{ID:int}", "Examples/Views/EditForm.dothtml");

            //зарегистрировать все
            //config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config, "Examples/Views"));
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            //явно зарегистрировать контрол  
            //config.Markup.AddMarkupControl("cc", "CustomControl", "Examples/Controls/CustomControl.dotcontrol"); 
            //config.Markup.AddCodeControls("cc", typeof(DotVVM.Example.DynamicControls.Controls.GridView2));

            //зарегистрировать все контролы
            config.Markup.AutoDiscoverControls(new DefaultControlRegistrationStrategy(config, "cc", "Examples/Controls"));
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
        }

        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.Services.AddSingleton<IControlTreeResolver, CustomControlTreeResolver>();
            //options.Services.AddSingleton<IViewCompiler, CustomViewCompiler>();
            options.AddDefaultTempStorages("Temp");
            options.AddDiagnosticServices();
        }
    }
}