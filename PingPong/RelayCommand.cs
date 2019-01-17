using System;
using System.Windows.Input;

namespace PingPong
{
    class RelayCommand : ICommand
    {
        private Func<object, bool> canExecute;
        private Action<object> execute;

        public RelayCommand(Func<object, bool> newCanExecute, Action<object> newExecute)
        {
            canExecute = newCanExecute;
            execute = newExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
