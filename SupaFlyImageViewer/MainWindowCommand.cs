using System;
using System.Windows.Input;

namespace SupaFlyImageViewer
{
    public class MainWindowCommand : ICommand
    {
        readonly Action action;

        public MainWindowCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return action != null;
        }

        public void Execute(object parameter)
        {
            action();
        }

        public event EventHandler CanExecuteChanged = delegate { };
    }
}