/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Converting an image into grayscale.
*/

using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace CH06
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            Uri uri = new Uri("ms-appx:///Assets/Image.jpg");
            WriteableBitmap bitmap = await BitmapFactory.New(1, 1).FromContent(uri);
            Photo.Source = bitmap.Gray();
        }
    }
}
