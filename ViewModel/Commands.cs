using System;
using System.Windows.Input;

namespace ViewModel
{
    // TODO: xml
    // TODO: почему название в множественном числе?
    public class Commands : ICommand
    {
        // TODO: xml
        private Action<object> _execute;

        // TODO: xml
        private Func<object, bool> _canExecute;

        // TODO: xml
        public Commands(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        // TODO: xml
        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        // TODO: xml
        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        // TODO: xml
        public event EventHandler CanExecuteChanged;
    }
}
