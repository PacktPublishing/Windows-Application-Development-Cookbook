/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a collection to a hub.
*/

using CH03.ViewModels;
using Windows.UI.Xaml;
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
            foreach (GalleryItemViewModel item in _vm.Items)
            {
                HubSection section = new HubSection();
                section.Header = item.Title;
                section.ContentTemplate = (DataTemplate)Resources["SectionTemplate"];
                section.DataContext = item;
                Hub.Sections.Add(section);
            }
        }
    }
}
