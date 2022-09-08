using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using WSSC.V4.SYS.DotVVMReference.Examples.ViewModels;
using WSSC.V4.SYS.DotVVMReference.Extensions;
using System.Reflection;

namespace WSSC.V4.SYS.DotVVMReference.Examples.Controls
{
    public class DocumentFieldsGrid : DotvvmMarkupControl
    {
        private readonly BindingCompilationService _bindingCompilationService;

        public DocumentFieldsGrid(BindingCompilationService bindingCompilationService)
        {
            _bindingCompilationService = bindingCompilationService;
        }

        protected override void OnLoad(IDotvvmRequestContext context)
        {
            if (DataContext is FileItem item)
            {
                int countControlID = 0;
                foreach (FieldValue documentField in item.FieldValue)
                {
                    DotvvmControl fieldControl = CreateControl(documentField, countControlID++);

                    HtmlLiteral breakLiteral = new HtmlLiteral();
                    breakLiteral.Html = "<br>";

                    Children.Add(fieldControl);
                    Children.Add(breakLiteral);
                }
            }
        }

        private DotvvmControl CreateControl(FieldValue documentField, int index)
        {
            FieldSetting setting = documentField.FieldSetting;

            PlaceHolder placeHolderField = new PlaceHolder();
            Literal literal = new Literal();
            literal.Text = setting.Name;
            literal.AddCssStyle("width", "150px");
            literal.AddCssStyle("display", "inline-block");

            HtmlGenericControl valueControl = CreateValueControl(documentField, setting, index);

            valueControl.AddCssStyle("width", "150px");
            valueControl.AddCssStyle("display", "inline-block");
            valueControl.ID = $"control_id_{setting.Type}_{index++}";

            placeHolderField.Children.Add(literal);

            if (valueControl != null)
                placeHolderField.Children.Add(valueControl);
            return placeHolderField;
        }

        private HtmlGenericControl CreateValueControl(FieldValue documentField, FieldSetting setting, int index)
        {
            switch (setting.Type)
            {
                case "int":
                    {
                        TextBox textBox = new TextBox();
                        EnshureBinding<int>(textBox, TextBox.TextProperty, index);
                        return textBox;
                    }
                case "string":
                    {
                        TextBox textBox = new TextBox();
                        EnshureBinding<string>(textBox, TextBox.TextProperty, index);
                        return textBox;
                    }
                case "bool":
                    {
                        CheckBox checkBox = new CheckBox();
                        EnshureBinding<bool>(checkBox, CheckBox.CheckedProperty, index);
                        return checkBox;
                    }
            }

            throw new NotImplementedException();
        }

        private void EnshureBinding<T>(DotvvmControl control, DotvvmProperty property, int index)
        {
            var expression = GetBinding<T>(index);

            var binding = ValueBindingExpression.CreateBinding(
                _bindingCompilationService,
                expression, this.GetDataContextType());

            control.SetBinding(property, binding);
        }

        private Expression<Func<object[], T>> GetBinding<T>(int index)
        {
            var param = Expression.Parameter(typeof(object[]));
            var expression = Expression.Lambda<Func<object[], T>>(
                Expression.Convert(
                    Expression.Property(
                    Expression.ArrayIndex(
                         Expression.Property(
                            Expression.Convert(
                                Expression.ArrayIndex(param, Expression.Constant(0)),
                                typeof(FileItem)), "FieldValue"),
                        Expression.Constant(index)),
                    "Value"), typeof(T))
                 , param);
            return expression;
        }
    }
}

