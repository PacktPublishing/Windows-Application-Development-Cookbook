/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Removing data from a SQLite database.
*/

using CH04.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm.InitializeDatabase();
            _vm.LoadCategories();
            _vm.LoadEntries();
        }
    }
}
