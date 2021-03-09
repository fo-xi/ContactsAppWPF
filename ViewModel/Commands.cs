using System;
using System.Windows.Input;

namespace ViewModel
{
    public class Commands : ICommand
    {
        private Action<object> _execute;

        private Func<object, bool> _canExecute;

        public Commands(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
