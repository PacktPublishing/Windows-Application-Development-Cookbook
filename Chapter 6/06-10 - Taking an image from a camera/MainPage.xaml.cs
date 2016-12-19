/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Taking an image from a camera.
*/

using System;
using Windows.Media.Capture;
using Windows.Storage;
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

        private async void BtnTake_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI capture = new CameraCaptureUI();
            capture.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            StorageFile file = await capture.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (file != null)
            {
                StorageFolder folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Album", CreationCollisionOption.OpenIfExists);
                string fileName = DateTime.Now.Ticks + ".jpg";
                await file.CopyAsync(folder, fileName, NameCollisionOption.ReplaceExisting);
                await file.DeleteAsync();

                file = await folder.GetFileAsync(fileName);
                FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.Read);
                BitmapImage image = new BitmapImage();
                image.SetSource(stream);
                Photo.Source = image;
            }
        }
    }
}
