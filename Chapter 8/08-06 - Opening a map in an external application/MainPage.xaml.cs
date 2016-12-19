/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Opening a map in an external application.
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

        private async void BtnTownHall2D_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("bingmaps:?cp=50.037348~22.003998&lvl=18");
            await Launcher.LaunchUriAsync(uri);
        }

        private async void BtnTownHall3D_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("bingmaps:?cp=50.037348~22.003998&lvl=18&pit=60");
            await Launcher.LaunchUriAsync(uri);
        }

        private async void BtnMarketSquare_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("bingmaps:?bb=50.037178_22.003736~50.037860_22.005581");
            await Launcher.LaunchUriAsync(uri);
        }
    }
}
