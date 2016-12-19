/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Using value converters with parameters.
*/

using CH03.Models;
using PropertyChanged;
using System.Windows.Input;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public bool IsPrimaryColor { get; set; } = true;
        public ICommand CmdChangeColor { get; set; }

        public MainViewModel()
        {
            CmdChangeColor = new RelayCommand(() => ChangeColor());
        }

        private void ChangeColor()
        {
            IsPrimaryColor = !IsPrimaryColor;
        }
    }
}
