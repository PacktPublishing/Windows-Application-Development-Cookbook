/*
    Exemplary file for Chapter 7 - Built-in Sensors.
    Recipe: Reading data from a compass.
*/

using System;
using Windows.Devices.Sensors;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH07
{
    public sealed partial class MainPage : Page
    {
        private Compass _compass;

        public MainPage()
        {
            InitializeComponent();
            _compass = Compass.GetDefault();
            if (_compass != null)
            {
                _compass.ReportInterval = Math.Max(16, _compass.MinimumReportInterval);
                _compass.ReadingChanged += Compass_ReadingChanged;
            }
        }

        private async void Compass_ReadingChanged(Compass sender, CompassReadingChangedEventArgs args)
        {
            double degrees = args.Reading.HeadingMagneticNorth;
            await Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () => Rotation.Angle = degrees);
        }

        private void Image_ImageOpened(object sender, RoutedEventArgs e)
        {
            Image image = (Image)sender;
            Rotation.CenterX = image.ActualWidth / 2;
            Rotation.CenterY = image.ActualHeight / 2;
        }
    }
}
