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
using WSSC.V4.SYS.DotVVMReference.Examples;

[assembly: OwinStartup(typeof(WSSC.V4.SYS.DotVVMReference.Startup))]

namespace WSSC.V4.SYS.DotVVMReference
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

            foreach (IDotvvmStartup dotvvmStartup in dotvvmStartups)
                app.UseDotVVM(dotvvmStartup, string.Empty);

            if (!dotvvmStartups.Any(x => x.GetType() == typeof(DotvvmStartup)))
                app.UseDotVVM(new DotvvmStartup(), string.Empty);
        }
    }
}
