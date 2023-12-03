using System.Windows.Input;

namespace Sweeter.Client.WPF
{
	public class RelayCommand : ICommand
	{
		#region Private Members

		/// <summary>
		/// The action to run
		/// </summary>
		private readonly Action? _Action;

        private readonly Action<object>? _Action2;

        #endregion

        #region Public Events

        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler? CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            _Action = action;
        }

        public RelayCommand(Action<object> action)
        {
            _Action2 = action;
        }

		#endregion

		#region Command Methods

		/// <summary>
		/// A relay command can always execute
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter) => true;

		/// <summary>
		/// Executes the commands Action
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
        {
            if (_Action != null)
                _Action();
            else
                _Action2(parameter);
        }

        #endregion
	}
}
