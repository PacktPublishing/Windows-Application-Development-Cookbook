/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Reading an XML file.
*/

using CH04.ViewModels;
using Windows.UI.Xaml.Controls;

namespace CH04.Views
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
