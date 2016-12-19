/*
    Exemplary file for Chapter 7 - Built-in Sensors.
    Recipe: Detecting motion using an accelerometer.
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
        private Accelerometer _accelerometer;
        private double _speedX = 0.0f;
        private double _speedY = 0.0f;

        public MainPage()
        {
            InitializeComponent();
            _accelerometer = Accelerometer.GetDefault();
            if (_accelerometer != null)
            {
                _accelerometer.ReportInterval = Math.Max(16, _accelerometer.MinimumReportInterval);
                _accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            }
        }

        private async void Accelerometer_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            double x = args.Reading.AccelerationX;
            double y = args.Reading.AccelerationY;
            double z = args.Reading.AccelerationZ;
            await Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () => UpdateBallLocation(x, y));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            double x = (Board.ActualWidth / 2) - 25;
            double y = (Board.ActualHeight / 2) - 25;
            Ball.SetValue(Canvas.LeftProperty, x);
            Ball.SetValue(Canvas.TopProperty, y);
        }

        private void UpdateBallLocation(double accelerometerX, double accelerometerY)
        {
            _speedX += accelerometerX / 3.0;
            _speedY -= accelerometerY / 3.0;

            double x = (double)Ball.GetValue(Canvas.LeftProperty);
            double y = (double)Ball.GetValue(Canvas.TopProperty);
            x += _speedX;
            y += _speedY;

            if (x > Board.ActualWidth - 50)
            {
                x = Board.ActualWidth - 50;
                _speedX = 0.0;
            }
            else if (x < 0)
            {
                x = 0;
                _speedX = 0.0;
            }

            if (y > Board.ActualHeight - 50)
            {
                y = Board.ActualHeight - 50;
                _speedY = 0.0;
            }
            else if (y < 0)
            {
                y = 0;
                _speedY = 0.0;
            }

            Ball.SetValue(Canvas.LeftProperty, x);
            Ball.SetValue(Canvas.TopProperty, y);
        }
    }
}
