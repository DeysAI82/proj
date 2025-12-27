using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace proj.Commands
{
    public class MyCommand(Action<object?> action, Func<object?, bool>? canExecute = null)
        : ICommand
    {
        private readonly Action<object?> action = action;
        private readonly Func<object?, bool>? canExecute = canExecute;
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            action(parameter);
        }
    }
    
}
