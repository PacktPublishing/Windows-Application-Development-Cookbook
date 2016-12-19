/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Getting coordinates of a clicked point on a map.
*/

using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CH08
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Map_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            Geopoint point = args.Location;
            Ellipse ellipse = new Ellipse()
            {
                Height = 10,
                Width = 10,
                Fill = new SolidColorBrush(Colors.Red)
            };
            Map.Children.Add(ellipse);
            MapControl.SetLocation(ellipse, point);
            MapControl.SetNormalizedAnchorPoint(ellipse, new Point(0.5, 0.5));
        }
    }
}
