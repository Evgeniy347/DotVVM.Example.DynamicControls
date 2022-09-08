using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Utils;
using Microsoft.Owin;
using Owin;
using DotVVM.Example.DynamicControls.Examples;
using System.Web.Hosting;

[assembly: OwinStartup(typeof(DotVVM.Example.DynamicControls.Startup))]

namespace DotVVM.Example.DynamicControls
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string[] filesDLL = Directory.GetFiles("C:\\Windows\\assembly\\gac_msil\\", "WSSC.V4.*.dll", SearchOption.AllDirectories)
                .Union(Directory.GetFiles("C:\\Windows\\Microsoft.NET\\assembly\\GAC_MSIL", "WSSC.V4.*.dll", SearchOption.AllDirectories))
                .ToArray();

            //Debugger.Launch();

            List<Type> types = new List<Type>();

            foreach (string fileDll in filesDLL)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(fileDll);
                    types.AddRange(assembly.GetTypes());
                }
                catch (NotSupportedException ex)
                {
                    //не C# библиотека 
                }
                catch (BadImageFormatException ex)
                {
                    //не C# библиотека
                }
                catch (ReflectionTypeLoadException ex)
                {
                    types.AddRange(ex.Types);
                }
            }

            // Так как при инициализации типа могу подгружаться другие сборки то в начале загружаем все сборки, 
            // затем ищем нужные типы и инициализируем их 
            IDotvvmStartup[] dotvvmStartups = types
                .Distinct()
                .Where(x => x != null && x.Implements(typeof(IDotvvmStartup)) && !x.IsInterface && !x.IsAbstract)
                .Select(x => (IDotvvmStartup)Activator.CreateInstance(x))
                .ToArray();

            var applicationPhysicalPath = HostingEnvironment.ApplicationPhysicalPath;

            foreach (IDotvvmStartup dotvvmStartup in dotvvmStartups)
                app.UseDotVVM(dotvvmStartup, applicationPhysicalPath);

            if (!dotvvmStartups.Any(x => x.GetType() == typeof(DotvvmStartup)))
                app.UseDotVVM(new DotvvmStartup(), applicationPhysicalPath);
        }
    }
}
