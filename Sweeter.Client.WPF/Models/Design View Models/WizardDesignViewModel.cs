using System.Windows.Controls;
using System.Windows.Input;

namespace Sweeter.Client.WPF
{
	public class WizardDesignViewModel : Wizard
	{
		public static WizardDesignViewModel Instance => Instance ?? new WizardDesignViewModel();

		public override Page[] Pages => throw new NotImplementedException();

		protected override void Finish()
		{
			throw new NotImplementedException();
		}
	}
}
