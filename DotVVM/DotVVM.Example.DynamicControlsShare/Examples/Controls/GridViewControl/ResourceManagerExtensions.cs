using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ResourceManagement;

namespace WSSC.V4.SYS.DotVVMReference.Controls
{
	public static class ResourceManagerExtensions
	{
		/// <summary>
		/// Adds the resources required by BusinessPack components.
		/// </summary>
		/// <param name="resourceManager">The resource manager.</param>
		/// <param name="context"></param>
		public static void AddBusinessPackRequiredResources(this ResourceManager resourceManager, IDotvvmRequestContext context)
		{
			resourceManager.AddRequiredResource(BusinessPackResources.BusinessPackScript);
			resourceManager.AddBusinessPackStylesheetResources(context);
		}

		private static void AddBusinessPackStylesheetResources(this ResourceManager resourceManager, IDotvvmRequestContext context)
		{
			switch (BusinessPackThemeProvider.CurrentTheme)
			{
				case BusinessPackTheme.None:
					resourceManager.AddBusinessPackStyleResourcesBasedOnBrowser(context, BusinessPackResources.BusinessPackStyleNone);
					break;
				case BusinessPackTheme.Enterprise:
					resourceManager.AddBusinessPackStyleResourcesBasedOnBrowser(context, BusinessPackResources.BusinessPackStyleDefault);
					break;
				case BusinessPackTheme.Bootstrap4:
					resourceManager.AddBusinessPackStyleResourcesBasedOnBrowser(context, BusinessPackResources.BusinessPackStyleBootstrap4);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private static void AddBusinessPackStyleResourcesBasedOnBrowser(this ResourceManager resourceManager, IDotvvmRequestContext context, string resourceName)
		{
			bool flag = false;
			if (((IDictionary<string, string[]>)context.HttpContext.Request.Headers).TryGetValue("user-agent", out string[] value))
			{
				flag = Regex.IsMatch(value.First(), "Trident/7.*rv:11");
			}
			resourceManager.AddRequiredResource(resourceName);
		}
	}
}