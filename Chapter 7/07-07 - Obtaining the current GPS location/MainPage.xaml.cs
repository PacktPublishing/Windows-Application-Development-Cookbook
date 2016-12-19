/*
    Exemplary file for Chapter 7 - Built-in Sensors.
    Recipe: Obtaining the current GPS location.
*/

using System;
using Windows.Devices.Geolocation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CH07
{
    public sealed partial class MainPage : Page
    {
        private Geolocator _geolocator;

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            GeolocationAccessStatus status = await Geolocator.RequestAccessAsync();
            if (status == GeolocationAccessStatus.Denied)
            {
                BtnNoAccess.Visibility = Visibility.Visible;
            }

            _geolocator = new Geolocator
            {
                DesiredAccuracyInMeters = 100,
                ReportInterval = 5000
            };
            _geolocator.PositionChanged += Geolocator_PositionChanged;
            _geolocator.StatusChanged += Geolocator_StatusChanged;
        }

        private async void Geolocator_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            Color color = GetColorForStatus(args.Status);
            await Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () => BorStatus.Background = new SolidColorBrush(color));

            if (args.Status == PositionStatus.Ready)
            {
                await Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    () => BtnNoAccess.Visibility = Visibility.Collapsed);
            }
        }

        private Color GetColorForStatus(PositionStatus status)
        {
            switch (status)
            {
                case PositionStatus.Ready: return Colors.GreenYellow;
                case PositionStatus.Initializing: return Colors.Yellow;
                case PositionStatus.NoData: return Colors.OrangeRed;
                case PositionStatus.Disabled: return Colors.Red;
                case PositionStatus.NotInitialized: return Colors.Gray;
                default: return Colors.Black;
            }
        }

        private async void Geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            double lat = args.Position.Coordinate.Latitude;
            double lon = args.Position.Coordinate.Longitude;

            double latMin = 49.0;
            double latMax = 54.84;
            double lonMin = 14.12;
            double lonMax = 24.15;

            double relX = (lon - lonMin) / (lonMax - lonMin);
            double relY = (latMax - lat) / (latMax - latMin);

            await Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {
                    if (relX >= 0 && relX <= 1
                        && relY >= 0 && relY <= 1)
                    {
                        Canvas canvas = (Canvas)EllUser.Parent;
                        EllUser.Margin = new Thickness(
                            relX * canvas.ActualWidth,
                            relY * canvas.ActualHeight,
                            0,
                            0);
                        EllUser.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        EllUser.Visibility = Visibility.Collapsed;
                    }
                });
        }
    }
}
