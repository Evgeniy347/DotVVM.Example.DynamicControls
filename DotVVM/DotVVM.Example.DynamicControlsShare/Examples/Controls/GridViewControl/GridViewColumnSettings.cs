
namespace WSSC.V4.SYS.DotVVMReference.Controls
{
	/// <summary>
	/// Represents GridView column settings (visibility, width, etc.).
	/// </summary>
	public class GridViewColumnSettings
	{
		/// <summary>
		/// Gets or sets the unique name of the column.
		/// </summary>
		public string ColumnName { get; set; }

		/// <summary>
		/// Gets or sets the value used to sort displayed columns.
		/// </summary>
		public int DisplayOrder { get; set; }

		/// <summary>
		/// Gets or sets the text displayed in GridView's header.
		/// </summary>
		public string DisplayText { get; set; }

		/// <summary>
		/// Gets or sets whether the column is displayed in GridView.
		/// </summary>
		public bool Visible { get; set; } = true;


		/// <summary>
		/// Gets or sets the width of column set by user.
		/// </summary>
		public double? Width { get; set; }
	}
}
