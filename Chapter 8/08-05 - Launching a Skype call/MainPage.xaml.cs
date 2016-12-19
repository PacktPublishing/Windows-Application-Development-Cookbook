/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Launching a Skype call.
*/

using System;
using Windows.System;
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

        private async void BtnStartCall_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("skype:marcinjamro?call");
            await Launcher.LaunchUriAsync(uri);
        }
    }
}
