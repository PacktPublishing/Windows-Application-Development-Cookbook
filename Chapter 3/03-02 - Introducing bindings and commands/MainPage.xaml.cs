/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Introducing bindings and commands.
*/

using CH03.ViewModels;
using Windows.UI.Xaml.Controls;

namespace CH03.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel _vm = null;

        public MainPage()
        {
            InitializeComponent();
            _vm = new MainViewModel();
            DataContext = _vm;
        }
    }
}
