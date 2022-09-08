using System;
using System.Linq.Expressions;
using DotVVM.BusinessPack.Binding;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Compilation.Javascript;
using DotVVM.Framework.Compilation.Javascript.Ast;
using DotVVM.Framework.Controls;
using DotVVM.Utils.HtmlElements;

namespace WSSC.V4.SYS.DotVVMReference.Controls
{ 
	public static class DotvvmControlExtensions
	{ 
		public static void SetValue<T>(this DotvvmBindableObject control, DotvvmProperty property, T value)
        {
			control.SetValue(property, value);
        }

        /// <summary>
        /// Adds the BusinessPack control binding to the wrapper element.
        /// </summary>
        public static void AddControlKnockoutDataBinding(this WrapperElement control, string controlName, ControlBinding bindingGroup)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			DotvvmControlExtensions.AddKoDataBinding(control.Attributes, "dotvvm-businesspack-" + controlName, (KnockoutBindingGroup)(object)bindingGroup);
		}

		/// <summary>
		/// Sets a client-side value binding to the specified property.
		/// </summary>
		public static void SetJsValueBinding<TControl, TValue>(this TControl control, Expression<Func<TControl, TValue>> property, string bindingExpression, bool forceObservable = false) where TControl : DotvvmBindableObject
		{
			control.SetJsValueBinding(property, bindingExpression, () => default(TValue), forceObservable);
		}

		/// <summary>
		/// Sets a client-side value binding to the specified property.
		/// </summary>
		public static void SetJsValueBinding<TControl, TValue>(this TControl control, Expression<Func<TControl, IValueBinding<TValue>>> property, string bindingExpression, bool forceObservable = false) where TControl : DotvvmBindableObject
		{
			((DotvvmBindableObject)(object)control).SetJsValueBinding(DotvvmBindableObjectHelper.GetDotvvmProperty<TControl, IValueBinding<TValue>>(control, property), bindingExpression, () => default(TValue), forceObservable);
		}

		/// <summary>
		/// Sets a client-side value binding to the specified property.
		/// </summary>
		public static void SetJsValueBinding(this DotvvmBindableObject control, DotvvmProperty property, string bindingExpression, bool forceObservable = false)
		{
			control.SetJsValueBinding(property, bindingExpression, () => property.DefaultValue, forceObservable);
		}

		/// <summary>
		/// Sets a client-side value binding to the specified property.
		/// </summary>
		public static void SetJsValueBinding<TControl, TValue>(this TControl control, Expression<Func<TControl, TValue>> property, string bindingExpression, Func<TValue> getServerSideValue, bool forceObservable = false) where TControl : DotvvmBindableObject
		{
			if (property == null)
			{
				throw new ArgumentNullException("property");
			}
			if (getServerSideValue == null)
			{
				throw new ArgumentNullException("getServerSideValue");
			}
			((DotvvmBindableObject)(object)control).SetJsValueBinding(DotvvmBindableObjectHelper.GetDotvvmProperty<TControl, TValue>(control, property), bindingExpression, getServerSideValue, forceObservable);
		}

		/// <summary>
		/// Sets a client-side value binding to the specified property.
		/// </summary>
		public static void SetJsValueBinding<TValue>(this DotvvmBindableObject control, DotvvmProperty property, string bindingExpression, Func<TValue> getServerSideValue, bool forceObservable = false)
		{
			if (property == null)
			{
				throw new ArgumentNullException("property");
			}
			if (bindingExpression == null)
			{
				throw new ArgumentNullException("bindingExpression");
			}
			if (getServerSideValue == null)
			{
				throw new ArgumentNullException("getServerSideValue");
			}
			Type typeFromHandle = typeof(TValue);
			JsExpression jsExpression = JsBindingExpressionBase.CreateJsExpression(bindingExpression, typeFromHandle, forceObservable);
			if (property.Name == "DataSource")
			{
				control.SetBinding(property, (IBinding)(object)new JsDataSourceBindingExpression<TValue>(jsExpression, () => getServerSideValue()));
			}
			else
			{
				control.SetBinding(property, (IBinding)(object)new JsValueBindingExpression<TValue>(jsExpression, () => getServerSideValue()));
			}
		}

		/// <summary>
		/// Sets a client-side object binding to the specified property.
		/// </summary>
		public static void SetJsObjectBinding<TControl, TValue>(this TControl control, Expression<Func<TControl, TValue>> property, TValue bindingValue) where TControl : DotvvmBindableObject
		{
			control.SetJsObjectBinding(DotvvmBindableObjectHelper.GetDotvvmProperty<TControl, TValue>(control, property), bindingValue);
		}

		/// <summary>
		/// Sets a client-side object binding to the specified property.
		/// </summary>
		public static void SetJsObjectBinding<TControl, TValue>(this TControl control, DotvvmProperty property, TValue bindingValue) where TControl : DotvvmBindableObject
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Expected O, but got Unknown
			JsExpression jsExpression = AnnotatableUtils.WithAnnotation<JsExpression>(
				JsAstHelpers.Invoke(JsAstHelpers.Member(JsAstHelpers.Member(
					JsAstHelpers.Member((JsExpression)new JsIdentifierExpression("DotVVM"), "BusinessPack", false), "Utils", false), "deepObservable", false), (JsExpression[])(object)new JsExpression[1] { (JsExpression)new JsLiteral((object)bindingValue) }), (object)ResultIsObservableAnnotation.Instance, true);
			if (property.Name == "DataSource")
			{
				((DotvvmBindableObject)control).SetBinding(property, (IBinding)(object)new JsDataSourceBindingExpression<TValue>(jsExpression, () => bindingValue));
			}
			else
			{
				((DotvvmBindableObject)control).SetBinding(property, (IBinding)(object)new JsValueBindingExpression<TValue>(jsExpression, () => bindingValue));
			}
		}

		/// <summary>
		/// Sets a client-side command binding to the specified property.
		/// </summary>
		public static void SetJsCommandBinding<TControl, TProperty>(this TControl control, Expression<Func<TControl, TProperty>> property, string commandExpression) where TControl : DotvvmBindableObject
		{
			control.SetJsCommandBinding(DotvvmBindableObjectHelper.GetDotvvmProperty<TControl, TProperty>(control, property), commandExpression);
		}

		/// <summary>
		/// Sets a client-side command binding to the specified property.
		/// </summary>
		public static void SetJsCommandBinding<TControl>(this TControl control, DotvvmProperty property, string commandExpression) where TControl : DotvvmBindableObject
		{
			((DotvvmBindableObject)control).SetBinding(property, (IBinding)(object)new JsCommandBindingExpression(commandExpression));
		}

		/// <summary>
		/// Enables automatic validation of the value bound to the given <paramref name="property" />.
		/// </summary>
		public static void EnableAutoValidation<TControl, TValue>(this TControl control, Expression<Func<TControl, TValue>> property) where TControl : DotvvmBindableObject
		{
			((DotvvmBindableObject)(object)control).EnableAutoValidation(DotvvmBindableObjectHelper.GetDotvvmProperty<TControl, TValue>(control, property));
		}

		/// <summary>
		/// Enables automatic validation of the value bound to the given <paramref name="property" />.
		/// </summary>
		public static void EnableAutoValidation(this DotvvmBindableObject control, DotvvmProperty property)
		{
			if ((bool)DotvvmControlExtensions.GetValueOrDefault(control, BusinessPack.AllowAutoValidationProperty, true) && !control.IsPropertySet((DotvvmProperty)(object)Validator.ValueProperty, true))
			{
				control.SetValueRaw((DotvvmProperty)(object)Validator.ValueProperty, control.GetValueRaw(property, true));
			}
		}

		/// <summary>
		/// Ensures <see cref="F:DotVVM.BusinessPack.BusinessPackCss.StateError" /> CSS class is used as an <see cref="F:DotVVM.Framework.Controls.Validator.InvalidCssClassProperty" />.
		/// It will not overwrite the CSS class set by user.
		/// </summary>
		public static void EnsureInvalidCssClass(this DotvvmBindableObject control)
		{
			if (control.IsPropertySet((DotvvmProperty)(object)Validator.ValueProperty, true))
			{
				string text = BusinessPackCss.StateError;
				if (control.IsPropertySet(Validator.InvalidCssClassProperty, true))
				{
					string value = control.GetValue<string>(Validator.InvalidCssClassProperty, true);
					text = ((value.IndexOf(text, StringComparison.InvariantCultureIgnoreCase) >= 0) ? value : (text + " " + value));
				}
				control.SetValueRaw(Validator.InvalidCssClassProperty, (object)text);
			}
		}
	}
}