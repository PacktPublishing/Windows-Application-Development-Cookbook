/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Downloading a file from the Internet.
*/

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH08
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnDownloadPhoto_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://jamro.biz/img/researcher-2.jpg";
            try
            {
                HttpClient httpClient = new HttpClient();
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                    "Photo.jpg",
                    CreationCollisionOption.ReplaceExisting);
                using (Stream fileStream = await file.OpenStreamForWriteAsync())
                {
                    using (Stream urlStream = await httpClient.GetStreamAsync(url))
                    {
                        await urlStream.CopyToAsync(fileStream);
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Cannot download the file {0} – exception: {1}", url, exception);
            }
        }
    }
}
