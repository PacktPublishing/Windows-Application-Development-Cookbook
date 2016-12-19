/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a collection to a list view.
*/

using System;
using CH03.ViewModels;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _vm.LoadData();
        }

        private async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserViewModel user = (UserViewModel)e.ClickedItem;
            MessageDialog dialog = new MessageDialog(
                string.Format("{0} is currently in {1}. The next birthday in {2} day(s).", user.Name, user.Location, user.DaysToBirthday),
                "Details of the selected user");
            dialog.Commands.Add(new UICommand("Close"));
            await dialog.ShowAsync();
        }
    }
}
