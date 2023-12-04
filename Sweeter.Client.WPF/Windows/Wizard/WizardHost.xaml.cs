using System.Windows;

namespace Sweeter.Client.WPF;

/// <summary>
/// Interaction logic for WizardHost.xaml
/// </summary>
public partial class WizardHost : Window
    {
        public WizardHost(Wizard wizard)
        {
            InitializeComponent();

            DataContext = wizard;

		Application.Current.MainWindow.Activated += MainWindow_Activated;
        }

	private void MainWindow_Activated(object? sender, EventArgs e)
	{
		this.Activate();
	}
}
