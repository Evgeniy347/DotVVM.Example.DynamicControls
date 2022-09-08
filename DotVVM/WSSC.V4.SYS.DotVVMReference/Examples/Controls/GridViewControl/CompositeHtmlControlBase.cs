using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using DotVVM.Utils.HtmlElements;

namespace WSSC.V4.SYS.DotVVMReference.Controls
{
	/// <summary>
	/// The base class for composite BusinessPack controls. It registers BusinessPack
	/// resources in OnInit phase.
	/// </summary>
	public abstract class CompositeHtmlControlBase : DotvvmCompositeHtmlControl, IBusinessPackControl
	{
		/// <summary>
		/// Gets the name used to find the client-side control instance.
		/// </summary>
		public virtual string ControlName => ((object)this).GetType().Name;

		/// <summary>
		/// Gets the service required to create bindings.
		/// </summary>
		protected BindingCompilationService BindingService { get; }

		/// <summary>
		/// Gets the factory used to build control's HTML structure.
		/// </summary>
		protected HtmlFactory HtmlFactory { get; } = new HtmlFactory();


		/// <inheritdoc />
		protected override string HiddenCssClass => BusinessPackCss.StateHidden;

		protected CompositeHtmlControlBase(BindingCompilationService bindingService)
		{
			BindingService = bindingService;
		}

		/// <inheritdoc />
		protected override void OnInit(IDotvvmRequestContext context)
		{
			context.ResourceManager.AddBusinessPackRequiredResources(context);
			this.OnInit(context);
		}

		/// <inheritdoc />
		protected override void OnPreRender(IDotvvmRequestContext context)
		{
			if (this.DataContext != null)
			{
				ValidateUsageAtRuntime(context);
			}
			((DotvvmBindableObject)(object)this).EnsureInvalidCssClass();
			this.OnPreRender(context);
		}

		/// <summary>
		/// Validates the control and its properties in PreRender phase.
		/// </summary>
		/// <param name="context">The DotVVM request context.</param>
		protected virtual void ValidateUsageAtRuntime(IDotvvmRequestContext context)
		{
		}
	}
}