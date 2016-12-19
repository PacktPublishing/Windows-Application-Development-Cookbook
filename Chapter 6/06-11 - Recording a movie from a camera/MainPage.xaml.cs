/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Recording a movie from a camera.
*/

using System;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH06
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnRecord_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI capture = new CameraCaptureUI();
            capture.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;
            StorageFile file = await capture.CaptureFileAsync(CameraCaptureUIMode.Video);
            if (file != null)
            {
                StorageFolder folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Movies", CreationCollisionOption.OpenIfExists);
                string fileName = DateTime.Now.Ticks + ".mp4";
                await file.CopyAsync(folder, fileName, NameCollisionOption.ReplaceExisting);
                await file.DeleteAsync();

                file = await folder.GetFileAsync(fileName);
                IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
                Video.SetSource(stream, file.ContentType);
            }
        }
    }
}
