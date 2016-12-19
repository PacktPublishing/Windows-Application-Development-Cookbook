/*
    Exemplary file for Chapter 9 - Testing and Submission.
    Recipe: Running a set of tests.
*/

using System;
using System.Windows.Input;

namespace CH09.Models
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
