/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Preparing a photo album with captions.
*/

using CH06.ViewModels;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CH06.Views
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
            _vm.Photos = new List<PhotoViewModel>()
            {
                new PhotoViewModel() { Url = "/Assets/01.jpg", Caption = "Picture Lake" },
                new PhotoViewModel() { Url = "/Assets/02.jpg", Caption = "North Cascades National Park" },
                new PhotoViewModel() { Url = "/Assets/03.jpg", Caption = "Canyon Road" },
                new PhotoViewModel() { Url = "/Assets/04.jpg", Caption = "Zion National Park" }
            };
        }
    }
}
