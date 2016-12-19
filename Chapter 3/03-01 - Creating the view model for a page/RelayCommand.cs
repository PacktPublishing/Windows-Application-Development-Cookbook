/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Creating the view model for a page.
*/

using System;
using System.Windows.Input;

namespace CH03.Models
{
    public class RelayCommand : ICommand
    {
        private Action _action = null;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
