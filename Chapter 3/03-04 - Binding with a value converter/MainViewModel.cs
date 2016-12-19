/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding with a value converter.
*/

using CH03.Models;
using PropertyChanged;
using System.Windows.Input;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public bool IsContentShown { get; set; } = true;
        public ICommand CmdToggleContent { get; set; }

        public MainViewModel()
        {
            CmdToggleContent = new RelayCommand(() => ToggleContent());
        }

        private void ToggleContent()
        {
            IsContentShown = !IsContentShown;
        }
    }
}
