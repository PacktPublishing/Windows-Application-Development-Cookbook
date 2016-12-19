/*
    Exemplary file for Chapter 7 - Built-in Sensors.
    Recipe: Obtaining the orientation of a device.
*/

using System;
using Windows.Devices.Sensors;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace CH07
{
    public sealed partial class MainPage : Page
    {
        private SimpleOrientationSensor _orientation;

        public MainPage()
        {
            InitializeComponent();
            _orientation = SimpleOrientationSensor.GetDefault();
            if (_orientation != null)
            {
                _orientation.OrientationChanged += Orientation_OrientationChanged;
            }
        }

        private async void Orientation_OrientationChanged(SimpleOrientationSensor sender, SimpleOrientationSensorOrientationChangedEventArgs args)
        {
            string orientation = GetText(args.Orientation);
            await Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () => LblOrientation.Text = orientation);
        }

        private string GetText(SimpleOrientation orientation)
        {
            switch (orientation)
            {
                case SimpleOrientation.Faceup: return "Face-up";
                case SimpleOrientation.Facedown: return "Face-down";
                case SimpleOrientation.NotRotated: return "Not rotated";
                case SimpleOrientation.Rotated90DegreesCounterclockwise: return "Rotated 90° counter-clockwise";
                case SimpleOrientation.Rotated180DegreesCounterclockwise: return "Rotated 180° counter-clockwise";
                case SimpleOrientation.Rotated270DegreesCounterclockwise: return "Rotated 270° counter-clockwise";
                default: return "Unknown";
            }
        }
    }
}
