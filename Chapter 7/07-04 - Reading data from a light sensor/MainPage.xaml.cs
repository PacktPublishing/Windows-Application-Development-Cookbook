/*
    Exemplary file for Chapter 7 - Built-in Sensors.
    Recipe: Reading data from a light sensor.
*/

using System;
using Windows.Devices.Sensors;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CH07
{
    public sealed partial class MainPage : Page
    {
        private LightSensor _sensor;

        public MainPage()
        {
            InitializeComponent();
            _sensor = LightSensor.GetDefault();
            if (_sensor != null)
            {
                _sensor.ReportInterval = Math.Max(16, _sensor.MinimumReportInterval);
                _sensor.ReadingChanged += Sensor_ReadingChanged;
            }
        }

        private async void Sensor_ReadingChanged(LightSensor sender, LightSensorReadingChangedEventArgs args)
        {
            float lux = args.Reading.IlluminanceInLux;
            LightStateEnum state = GetState(lux);
            await Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () => ChangeMode(state));
        }

        private LightStateEnum GetState(float lux)
        {
            if (lux < 50)
            {
                return LightStateEnum.Low;
            }
            else if (lux < 1500)
            {
                return LightStateEnum.Medium;
            }
            else
            {
                return LightStateEnum.High;
            }
        }

        private void ChangeMode(LightStateEnum state)
        {
            Color background = Colors.White;
            Color foreground = Colors.Black;
            switch (state)
            {
                case LightStateEnum.Medium:
                    background = Colors.Gray;
                    foreground = Colors.Black;
                    break;
                case LightStateEnum.Low:
                    background = Colors.Black;
                    foreground = Colors.LightGray;
                    break;
            }
            Page.Background = new SolidColorBrush(background);
            Symbol.Foreground = new SolidColorBrush(foreground);
            Text.Foreground = new SolidColorBrush(foreground);
        }
    }
}
