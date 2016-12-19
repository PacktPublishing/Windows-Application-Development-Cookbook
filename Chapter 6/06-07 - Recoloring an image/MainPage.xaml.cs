/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Recoloring an image.
*/

using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
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
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            using (IRandomAccessStream inputStream = await file.OpenAsync(FileAccessMode.Read))
            {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(inputStream);
                PixelDataProvider provider = await decoder.GetPixelDataAsync(
                    BitmapPixelFormat.Bgra8,
                    BitmapAlphaMode.Straight,
                    new BitmapTransform()
                    {
                        ScaledWidth = (uint)bitmap.PixelWidth,
                        ScaledHeight = (uint)bitmap.PixelHeight
                    },
                    ExifOrientationMode.IgnoreExifOrientation,
                    ColorManagementMode.DoNotColorManage);
                byte[] pixels = provider.DetachPixelData();
                for (var i = 0; i < pixels.Length; i += 4)
                {
                    byte b = pixels[i];
                    byte g = pixels[i + 1];
                    byte r = pixels[i + 2];
                    if (r >= 175 && r <= 255
                        && g >= 175 && g <= 255
                        && b >= 175 && b <= 255)
                    {
                        pixels[i] = 0;
                        pixels[i + 1] = 0;
                        pixels[i + 2] = 255;
                    }
                }

                using (Stream outputStream = bitmap.PixelBuffer.AsStream())
                {
                    await outputStream.WriteAsync(pixels, 0, pixels.Length);
                }
            }

            Photo.Source = bitmap;
        }
    }
}
