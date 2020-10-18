using System;
using System.Windows.Input;

namespace CustomCodec_WPF.MVVM.Models.Commands
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action action;
        private Func<object> function;
        private Action<object> _action;
        private bool canExecute;

        public Command(Action action, bool canExecute = true)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public Command(Func<object> function, bool canExecute = true)
        {
            this.function = function;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
