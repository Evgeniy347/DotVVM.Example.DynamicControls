using System;
using DotVVM.Framework.Binding;

namespace WSSC.V4.SYS.DotVVMReference.Controls
{ 
	/// <summary>
	/// The base class for controls rendering icons.
	/// </summary>
	public abstract class IconBase : CompositeHtmlControlBase, ICloneable
	{
		protected IconBase(BindingCompilationService bindingService)
			: base(bindingService)
		{
		}

		/// <summary>
		/// Returns a clone of the current icon.
		/// </summary>
		public abstract IconBase Clone();

		object ICloneable.Clone()
		{
			return Clone();
		}
	}
}