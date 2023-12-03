using System.Windows;
using System.Windows.Controls;

namespace Sweeter.Client.WPF
{
	/// <summary>
	/// Interaction logic for Hub.xaml
	/// </summary>
	public partial class Hub : Window
	{
		public Hub()
		{
			InitializeComponent();
		}

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Domain? domain = (sender as ListBox)?.SelectedItem as Domain;
			if (domain == null)
				return;
			((HubViewModel)DataContext).ChangeDomain(domain);
        }
    }
}
