using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Utils;

namespace DotVVM.Example.DynamicControls.Examples.Controls
{
    [ControlMarkupOptions(AllowContent = false)]
    public class FieldTextControl : HtmlGenericControl
    {
        private FormatValueType resolvedValueType;

        private string? implicitFormatString;

        public static readonly DotvvmProperty EnabledProperty = DotvvmPropertyWithFallback.Register<bool, FieldTextControl>("Enabled", FormControls.EnabledProperty);

        public static readonly DotvvmProperty FormatStringProperty = DotvvmProperty.Register<string, FieldTextControl>((FieldTextControl t) => t.FormatString);

        public static readonly DotvvmProperty ChangedProperty = DotvvmProperty.Register<Command, FieldTextControl>((FieldTextControl t) => t.Changed);

        public static readonly DotvvmProperty TextInputProperty = DotvvmProperty.Register<Command, FieldTextControl>((FieldTextControl t) => t.TextInput);

        public static readonly DotvvmProperty SelectAllOnFocusProperty = DotvvmProperty.Register((FieldTextControl t) => t.SelectAllOnFocus, defaultValue: false);

        public static readonly DotvvmProperty TextProperty = DotvvmProperty.Register((Expression<Func<FieldTextControl, object?>>)((FieldTextControl t) => t.Text), (object)"", isValueInherited: false);

        public static readonly DotvvmProperty TypeProperty = DotvvmProperty.Register((FieldTextControl c) => c.Type, TextBoxType.Normal);

        [MarkupOptions(AllowBinding = false)]
        [Obsolete("Use `UpdateTextOnInput` instead.")]
        public static readonly DotvvmProperty UpdateTextAfterKeydownProperty = DotvvmProperty.Register<bool, FieldTextControl>("UpdateTextAfterKeydown", defaultValue: false);

        public static readonly DotvvmProperty UpdateTextOnInputProperty = DotvvmPropertyWithFallback.Register<bool, FieldTextControl>("UpdateTextOnInput", UpdateTextAfterKeydownProperty, isValueInherited: true);

        [Obsolete("ValueType property is no longer required, it is automatically inferred from compile-time type of Text binding")]
        public static readonly DotvvmProperty ValueTypeProperty = DotvvmProperty.Register((FieldTextControl t) => t.ValueType, FormatValueType.Text);

        public bool Enabled
        {
            get
            {
                return (bool)GetValue(EnabledProperty);
            }
            set
            {
                SetValue(EnabledProperty, value);
            }
        }

        [MarkupOptions(AllowBinding = false)]
        public string? FormatString
        {
            get
            {
                return (string)GetValue(FormatStringProperty);
            }
            set
            {
                SetValue(FormatStringProperty, value);
            }
        }

        public Command? Changed
        {
            get
            {
                return (Command)GetValue(ChangedProperty);
            }
            set
            {
                SetValue(ChangedProperty, value);
            }
        }

        public Command? TextInput
        {
            get
            {
                return (Command)GetValue(TextInputProperty);
            }
            set
            {
                SetValue(TextInputProperty, value);
            }
        }

        public bool SelectAllOnFocus
        {
            get
            {
                return (bool)GetValue(SelectAllOnFocusProperty);
            }
            set
            {
                SetValue(SelectAllOnFocusProperty, value);
            }
        }

        [MarkupOptions(Required = true)]
        public string Text
        {
            get
            {
                return Convert.ToString(GetValue(TextProperty)).NotNull();
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        [MarkupOptions(AllowBinding = false)]
        public TextBoxType Type
        {
            get
            {
                return (TextBoxType)GetValue(TypeProperty);
            }
            set
            {
                SetValue(TypeProperty, value);
            }
        }

        [MarkupOptions(AllowBinding = false)]
        public bool UpdateTextOnInput
        {
            get
            {
                return (bool)GetValue(UpdateTextOnInputProperty);
            }
            set
            {
                SetValue(UpdateTextOnInputProperty, value);
            }
        }

        [MarkupOptions(AllowBinding = false)]
        [Obsolete("ValueType property is no longer required, it is automatically inferred from compile-time type of Text binding")]
        public FormatValueType ValueType
        {
            get
            {
                return (FormatValueType)GetValue(ValueTypeProperty);
            }
            set
            {
                SetValue(ValueTypeProperty, value);
            }
        }

        public static FormatValueType ResolveValueType(IValueBinding? binding)
        {
            if (binding?.ResultType == typeof(DateTime) || binding?.ResultType == typeof(DateTime?))
            {
                return FormatValueType.DateTime;
            }

            if (binding != null && (binding!.ResultType.IsNumericType() || (Nullable.GetUnderlyingType(binding!.ResultType)?.IsNumericType() ?? false)))
            {
                return FormatValueType.Number;
            }

            return FormatValueType.Text;
        }

        protected override void OnPreRender(IDotvvmRequestContext context)
        {
            bool flag = Type.TryGetFormatString(out implicitFormatString);
            if (!string.IsNullOrEmpty(FormatString) && flag)
            {
                throw new NotSupportedException($"Property FormatString cannot be used with Type set to '{Type}'." + $" In this case browsers localize '{Type}' themselves.");
            }

            if (!flag || implicitFormatString != null)
            {
                if (ValueType != 0)
                {
                    resolvedValueType = ValueType;
                }
                else
                {
                    resolvedValueType = ResolveValueType(GetValueBinding(TextProperty));
                }
            }

            if (resolvedValueType != 0)
            {
                context.ResourceManager.AddCurrentCultureGlobalizationResource();
            }

            base.OnPreRender(context);
        }
          
        protected override void AddAttributesToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            AddEnabledPropertyToRender(writer);
            AddTypeAttributeToRender(writer);
            AddChangedPropertyToRender(writer, context);
            AddSelectAllOnFocusPropertyToRender(writer, context);
            AddBindingToRender(writer);
        }

        protected override void RenderContents(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            if (Type == TextBoxType.MultiLine && GetValueBinding(TextProperty) == null)
            {
                writer.WriteText(Text);
            }
        }

        private void AddEnabledPropertyToRender(IHtmlWriter writer)
        {
            object valueRaw = GetValueRaw(EnabledProperty);
            if (!(valueRaw is bool))
            {
                IValueBinding valueBinding = valueRaw as IValueBinding;
                if (valueBinding != null)
                {
                    writer.AddKnockoutDataBind("enable", valueBinding.GetKnockoutBindingExpression(this));
                }
                else if (!Enabled)
                {
                    writer.AddAttribute("disabled", "disabled");
                }
            }
            else if (!(bool)valueRaw)
            {
                writer.AddAttribute("disabled", "disabled");
            }
        }

        private void AddBindingToRender(IHtmlWriter writer)
        {
            IHtmlWriter writer2 = writer;
            writer2.AddKnockoutDataBind("dotvvm-FieldTextControl-text", this, TextProperty, delegate
            {
                if (Type != TextBoxType.MultiLine)
                {
                    writer2.AddAttribute("value", Text);
                }
            }, UpdateTextOnInput ? "input" : null, renderEvenInServerRenderingMode: true);
            if (resolvedValueType != 0)
            {
                string value = FormatString;
                if (string.IsNullOrEmpty(value))
                {
                    value = implicitFormatString ?? "G";
                }

                writer2.AddAttribute("data-dotvvm-format", value);
                if (resolvedValueType == FormatValueType.DateTime)
                {
                    writer2.AddAttribute("data-dotvvm-value-type", "datetime");
                }
                else if (resolvedValueType == FormatValueType.Number)
                {
                    writer2.AddAttribute("data-dotvvm-value-type", "number");
                }
            }
        }

        private void AddChangedPropertyToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            ICommandBinding commandBinding = GetCommandBinding(ChangedProperty);
            ICommandBinding commandBinding2 = GetCommandBinding(TextInputProperty);
            base.AddAttributesToRender(writer, context);
            if (commandBinding != null)
            {
                writer.AddAttribute("onchange", KnockoutHelper.GenerateClientPostBackScript("Changed", commandBinding, this, useWindowSetTimeout: true, false, isOnChange: true), append: true, ";");
            }

            if (commandBinding2 != null)
            {
                writer.AddAttribute("oninput", KnockoutHelper.GenerateClientPostBackScript("TextInput", commandBinding2, this, useWindowSetTimeout: true, false, isOnChange: true), append: true, ";");
            }
        }

        private void AddSelectAllOnFocusPropertyToRender(IHtmlWriter writer, IDotvvmRequestContext context)
        {
            object valueRaw = GetValueRaw(SelectAllOnFocusProperty);
            if (valueRaw is bool)
            {
                if (!(bool)valueRaw)
                {
                    return;
                }
            }
            else
            {
                IValueBinding valueBinding = valueRaw as IValueBinding;
                if (valueBinding != null)
                {
                    writer.AddKnockoutDataBind("dotvvm-FieldTextControl-select-all-on-focus", valueBinding.GetKnockoutBindingExpression(this));
                    return;
                }
            }

            writer.AddKnockoutDataBind("dotvvm-FieldTextControl-select-all-on-focus", JsonConvert.ToString(SelectAllOnFocus));
        }

        private void AddTypeAttributeToRender(IHtmlWriter writer)
        {
            TextBoxType type = Type;
            if (type.TryGetTagName(out var tagName))
            {
                base.TagName = tagName;
                if (type == TextBoxType.Normal && !base.Attributes.ContainsKey("type"))
                {
                    writer.AddAttribute("type", "text");
                }

                return;
            }

            if (type.TryGetInputType(out var inputType))
            {
                writer.AddAttribute("type", inputType);
                base.TagName = "input";
                return;
            }

            throw new NotSupportedException($"FieldTextControl Type '{type}' not supported");
        }
    }
}
