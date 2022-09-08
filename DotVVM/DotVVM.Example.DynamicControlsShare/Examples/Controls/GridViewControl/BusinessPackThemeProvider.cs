
namespace WSSC.V4.SYS.DotVVMReference.Controls
{
	public class BusinessPackThemeProvider
	{
		public static BusinessPackTheme CurrentTheme { get; private set; } = BusinessPackTheme.Enterprise;


		public static void SetCurrentTheme(BusinessPackTheme theme)
		{
			CurrentTheme = theme;
		}
	}
}
