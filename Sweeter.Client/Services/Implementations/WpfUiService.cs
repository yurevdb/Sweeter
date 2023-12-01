using System.Windows;

namespace Sweeter.Client.WPF
{
	public class WpfUiService : UiService
	{
		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}
	}
}
