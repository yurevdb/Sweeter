using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sweeter.Client.WPF;

public abstract class Wizard : INotifyPropertyChanged
{
	#region Private Members

	private int currentPageIndex = 0;

	#endregion

	#region Public Properties

	public Page CurrentPage { get; private set; }

	public abstract Page[] Pages { get; }

	public bool CanGotoNextPage => currentPageIndex < Pages.Length - 1;
	public bool CanGotoPreviousPage => currentPageIndex > 0 && Pages.Length > 1;

	#endregion

	#region Public Commands

	public ICommand NextPageCommand { get; }
	public ICommand PreviousPageCommand { get; }

	public ICommand FinishCommand { get; }

	public ICommand CancelCommand { get; }

	#endregion

	#region Constructor

	public Wizard() 
	{
		NextPageCommand = new RelayCommand(NextPage);
		PreviousPageCommand = new RelayCommand(PreviousPage);
		FinishCommand = new RelayCommand(host => FinishWizard((WizardHost)host));
		CancelCommand = new RelayCommand(host => Cancel((WizardHost)host));

		if (Pages.Length > 0)
			CurrentPage = Pages[currentPageIndex];
		NotifyPropertyChanged(nameof(CurrentPage));
	}

	#endregion

	#region Abstract Functions

	protected virtual void Finish() { }

	#endregion

	#region Private Helpers

	private void Cancel(WizardHost host)
	{
		host.Close();
	}

	private void FinishWizard(WizardHost host)
	{
		Finish();
		host.Close();
	}

	private void NextPage()
	{
		if (!CanGotoNextPage)
			return;

		CurrentPage = Pages[++currentPageIndex];

		NotifyPropertyChanged(nameof(CurrentPage));
		NotifyPropertyChanged(nameof(CanGotoNextPage));
		NotifyPropertyChanged(nameof(CanGotoPreviousPage));
	}

	private void PreviousPage()
	{
		if (!CanGotoPreviousPage)
			return;

		CurrentPage = Pages[--currentPageIndex];

		NotifyPropertyChanged(nameof(CurrentPage));
		NotifyPropertyChanged(nameof(CanGotoNextPage));
		NotifyPropertyChanged(nameof(CanGotoPreviousPage));
	}

	#endregion

	#region Implementations

	public event PropertyChangedEventHandler? PropertyChanged;

	protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	#endregion
}
