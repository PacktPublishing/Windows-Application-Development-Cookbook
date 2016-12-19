/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Reading a JSON file.
*/

using System;
using System.Windows.Input;

namespace CH04.Models
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
