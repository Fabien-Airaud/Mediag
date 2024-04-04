using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class RelayCommand(Predicate<object?> canExecute, Action<object?> execute) : ICommand
    {
        private readonly Predicate<object?> _canExecute = canExecute;
        private readonly Action<object?> _execute = execute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter) { return _canExecute(parameter); }

        public void Execute(object? parameter) { _execute(parameter); }
    }
}
