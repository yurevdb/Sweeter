using System.ComponentModel;
using System.Windows;

namespace Sweeter.Client.WPF
{
	/// <summary>
	/// Interaction logic for WizardHost.xaml
	/// </summary>
	public partial class WizardHost : Window
    {
        public WizardHost(Wizard wizard)
        {
            InitializeComponent();

            DataContext = wizard;
        }
    }
}
