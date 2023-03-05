using System;
using System.Windows.Input;

namespace Bowling.Commands
{
    public class RelayCommand : ICommand
    {
        private Action _methodToExecute;
        private Func<bool> _canExecute;

        public RelayCommand(Action methodToExecute, Func<bool> canExecute)
        {
            _methodToExecute = methodToExecute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (this._canExecute == null)
            {
                return true;
            }
            else
            {
                bool result = this._canExecute.Invoke();
                return result;
            }
        }

        public void Execute(object? parameter)
        {
            _methodToExecute.Invoke();
        }
    }
}
