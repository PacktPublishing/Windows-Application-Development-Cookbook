/*
    Exemplary file for Chapter 9 - Testing and Submission.
    Recipe: Running a set of tests.
*/

using CH09.Models;
using CH09.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH09.Views
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

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Consumption consumption = (Consumption)button.DataContext;
            _vm.DeleteConsumption(consumption);
        }
    }
}
