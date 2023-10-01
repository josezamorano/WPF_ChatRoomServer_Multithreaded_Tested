using System;
using System.Windows.Input;

namespace PresentationLayer.MVVM.Base
{
    internal class CommandBaseViewModel : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public CommandBaseViewModel(Action<object> execute)
        {
            _execute = execute;
        }

        public CommandBaseViewModel(Action<object> execute , Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged 
        { 
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value;}
        }

        public bool CanExecute(object? parameter)
        {
            bool result = (_canExecute == null) ? true : (_canExecute(parameter));
            return result;  
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
