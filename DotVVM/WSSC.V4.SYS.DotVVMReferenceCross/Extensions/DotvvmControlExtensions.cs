using DotVVM.Framework.Configuration;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace WSSC.V4.SYS.DotVVMReference.Extensions
{
    public static class DotvvmControlExtensions
    {
        public static int GetValueInt(this IHttpContext httpContext, string paramName) =>
            GetValue(httpContext, paramName, int.Parse);

        public static string GetValueString(this IHttpContext httpContext, string paramName) =>
            GetValue(httpContext, paramName, x => x);

        public static T GetValue<T>(IHttpContext httpContext, string paramName, Func<string, T> parcer)
        {
            IHttpRequest httpRequest = httpContext.Request;

            if (!httpRequest.Query.TryGetValue(paramName, out string value) || string.IsNullOrEmpty(value))
            {
                string contentType = "application/x-www-form-urlencoded";
                if (httpRequest.ContentType == contentType)
                {
                    Dictionary<string, string> dic = httpContext.GetItem<Dictionary<string, string>>(contentType);
                    if (dic == null)
                    {
                        using (StreamReader reader = new StreamReader(httpRequest.Body))
                        {
                            string body = reader.ReadToEnd();

                            dic = body.Split('&')
                                .Select(x => x.Split('='))
                                .ToDictionary(x => x.First(), x => x.Last());

                            httpContext.SetItem(contentType, dic);
                        }

                    }

                    if (!dic.TryGetValue(paramName, out value) || string.IsNullOrEmpty(value))
                        return default;
                }
                else
                {
                    return default;
                }
            }

            try
            {
                return parcer(value);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обработке параметра '{paramName}'", ex);
            }
        }

        public static string RenderControlToHtml(this DotvvmControl control)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            StringBuilder sb = new StringBuilder();
            using (StringWriter stWriter = new StringWriter(sb))
            {
                DotvvmConfiguration configuration = DotvvmConfiguration.CreateDefault(); 
                DotvvmRequestContext context = new DotvvmRequestContext(null, configuration, null);
                
                HtmlWriter writer = new HtmlWriter(stWriter, context); 

                control.Render(writer, context);
                return sb.ToString();
            }
        }
    }
}
