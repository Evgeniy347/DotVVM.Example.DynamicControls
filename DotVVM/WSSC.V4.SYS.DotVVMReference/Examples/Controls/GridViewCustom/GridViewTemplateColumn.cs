using DotVVM.Framework.Binding;
using DotVVM.Framework.Compilation.ControlTree.Resolved;
using DotVVM.Framework.Compilation.Validation;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;

namespace WSSC.V4.SYS.DotVVMReference.Controls
{

    [ControlMarkupOptions(AllowContent = false, DefaultContentProperty = nameof(ContentTemplate))]
    public class GridViewTemplateColumn2 : GridViewColumn2
    {

        [MarkupOptions(AllowBinding = false, MappingMode = MappingMode.InnerElement, Required = true)]
        public ITemplate? ContentTemplate
        {
            get { return (ITemplate?)GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }
        public static readonly DotvvmProperty ContentTemplateProperty
            = DotvvmProperty.Register<ITemplate?, GridViewTemplateColumn2>(c => c.ContentTemplate, null);


        [MarkupOptions(AllowBinding = false, MappingMode = MappingMode.InnerElement)]
        public ITemplate? EditTemplate
        {
            get { return (ITemplate?)GetValue(EditTemplateProperty); }
            set { SetValue(EditTemplateProperty, value); }
        }
        public static readonly DotvvmProperty EditTemplateProperty
            = DotvvmProperty.Register<ITemplate?, GridViewTemplateColumn2>(c => c.EditTemplate, null);


        public override void CreateControls(IDotvvmRequestContext context, DotvvmControl container)
        {
            ContentTemplate.NotNull("GridViewTemplateColumn2.ContentTemplate must be set")
                           .BuildContent(context, container);
        }

        public override void CreateEditControls(IDotvvmRequestContext context, DotvvmControl container)
        {
            if (EditTemplate == null) throw new DotvvmControlException(this, "EditTemplate must be set when editing is allowed in a GridView.");
            EditTemplate.BuildContent(context, container);
        }
    }
}
