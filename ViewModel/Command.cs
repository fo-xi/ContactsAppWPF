using System;
using System.Windows.Input;

namespace ViewModel
{
    // TODO: xml (+)
    // TODO: почему название в множественном числе? (+)
    /// <summary>
    /// The class that is responsible for the command.
    /// </summary>
    public class Command : ICommand
    {
        // TODO: xml (+)
        /// <summary>
        /// Represents a method.
        /// </summary>
        private Action<object> _execute;

        // TODO: xml (+)
        /// <summary>
        /// Will determine whether the command can be executed or not.
        /// </summary>
        private Func<object, bool> _canExecute;

        // TODO: xml (+)
        /// <summary>
        /// Creating a command.
        /// </summary>
        /// <param name="execute">Represents a method..</param>
        /// <param name="canExecute">Will determine whether the command can be executed or not.</param>
        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        // TODO: xml (+)
        /// <summary>
        /// Determines if a command can be executed.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        // TODO: xml (+)
        /// <summary>
        /// Executes command logic.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        // TODO: xml (+)
        /// <summary>
        /// Called when conditions change,
        /// indicating whether the command can be executed.
        /// </summary>
        public event EventHandler CanExecuteChanged;
    }
}
