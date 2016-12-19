/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Writing a JSON file.
*/

using CH04.ViewModels;
using System.Collections.Generic;
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

        private void LsvLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            List<string> languages = new List<string>();
            foreach (ListViewItem item in listView.SelectedItems)
            {
                string language = (string)item.Tag;
                languages.Add(language);
            }
            _vm.Languages = languages;
        }
    }
}
