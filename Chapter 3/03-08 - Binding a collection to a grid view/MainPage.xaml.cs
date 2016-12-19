/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a collection to a grid view.
*/

using CH03.ViewModels;
using System;
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

        private async void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            CategoryViewModel category = (CategoryViewModel)e.ClickedItem;
            MessageDialog dialog = new MessageDialog(
                string.Format("The category contains {0} article(s).", category.Count),
                category.Name);
            dialog.Commands.Add(new UICommand("Close"));
            await dialog.ShowAsync();
        }
    }
}
