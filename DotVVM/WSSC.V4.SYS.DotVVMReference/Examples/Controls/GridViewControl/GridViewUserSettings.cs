using System.Collections.Generic;
 
namespace WSSC.V4.SYS.DotVVMReference.Controls
{

	/// <summary>
	/// Represents user's GridView settings (visibility of column, etc.).
	/// </summary>
	public class GridViewUserSettings
	{
		/// <summary>
		/// Gets or sets a list of GridView columns and their settings.
		/// </summary>
		public List<GridViewColumnSettings> ColumnsSettings { get; set; } = new List<GridViewColumnSettings>(0);

	}
}
