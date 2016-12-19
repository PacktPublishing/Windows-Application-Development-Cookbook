/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Opening a website in a default browser.
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

        private async void BtnOpenWebsite_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("http://jamro.biz"));
        }
    }
}
