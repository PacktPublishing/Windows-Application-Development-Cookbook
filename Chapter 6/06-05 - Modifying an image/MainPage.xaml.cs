/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Modifying an image.
*/

using System;
using Windows.UI;
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
            WriteableBitmap bitmap = await BitmapFactory.New(1, 1).FromContent(new Uri("ms-appx:///Assets/Image.jpg"));
            bitmap = bitmap.AdjustContrast(50.0);
            bitmap = bitmap.AdjustBrightness(50);
            bitmap = bitmap.Flip(WriteableBitmapExtensions.FlipMode.Vertical);
            bitmap.FillRectangle(10, 10, 30, 30, Colors.DarkBlue);
            bitmap.FillRectangle(
                bitmap.PixelWidth - 30,
                bitmap.PixelHeight - 30,
                bitmap.PixelWidth - 10,
                bitmap.PixelHeight - 10,
                Colors.RoyalBlue);
            Photo.Source = bitmap;
        }
    }
}
