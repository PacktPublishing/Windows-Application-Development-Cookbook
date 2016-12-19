/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Choosing a file to open.
*/

using System;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace CH06
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnChoose_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".jpg");
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.Read);
                BitmapImage image = new BitmapImage();
                image.SetSource(stream);
                Photo.Source = image;
            }
        }
    }
}
