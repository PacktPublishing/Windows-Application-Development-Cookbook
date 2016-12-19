/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Scanning a QR code.
*/

using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ZXing;
using ZXing.Mobile;

namespace CH06
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MobileBarcodeScanningOptions options = new MobileBarcodeScanningOptions();
            options.PossibleFormats = new List<BarcodeFormat>() { BarcodeFormat.QR_CODE };
            MobileBarcodeScanner scanner = new MobileBarcodeScanner();
            Result result = await scanner.Scan(options);
            if (result != null)
            {
                Frame.Navigate(typeof(ResultPage), result.Text);
            }
        }
    }
}
