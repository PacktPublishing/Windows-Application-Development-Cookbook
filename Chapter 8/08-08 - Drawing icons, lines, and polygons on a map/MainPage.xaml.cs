/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Drawing icons, polylines, and polygons on a map.
*/

using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;

namespace CH08
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BasicGeoposition center = new BasicGeoposition()
            {
                Latitude = 50.0406,
                Longitude = 21.9995
            };
            Map.Center = new Geopoint(center);
            Map.ZoomLevel = 15;
            AddPolygon();
            AddIcons();
            AddPolyline();
        }

        private void AddIcons()
        {
            MapIcon iconCastle = new MapIcon()
            {
                Title = "Rzeszow Castle",
                Location = new Geopoint(new BasicGeoposition() { Latitude = 50.0325, Longitude = 22.0007 }),
                CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible,
                NormalizedAnchorPoint = new Point(0.5, 1.0)
            };
            MapIcon iconTownHall = new MapIcon()
            {
                Title = "Rzeszow Town Hall",
                Location = new Geopoint(new BasicGeoposition() { Latitude = 50.0373, Longitude = 22.0039 }),
                CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible,
                NormalizedAnchorPoint = new Point(0.5, 1.0)
            };
            MapIcon iconFarnyChurch = new MapIcon()
            {
                Title = "Farny Church",
                Location = new Geopoint(new BasicGeoposition() { Latitude = 50.0378, Longitude = 22.0018 }),
                CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible,
                NormalizedAnchorPoint = new Point(0.5, 1.0)
            };
            Map.MapElements.Add(iconCastle);
            Map.MapElements.Add(iconTownHall);
            Map.MapElements.Add(iconFarnyChurch);
        }

        private void AddPolyline()
        {
            MapPolyline line = new MapPolyline()
            {
                Path = new Geopath(new List<BasicGeoposition>()
                {
                    new BasicGeoposition() { Latitude = 50.037612, Longitude = 22.001645 },
                    new BasicGeoposition() { Latitude = 50.037476, Longitude = 22.001619 },
                    new BasicGeoposition() { Latitude = 50.036658, Longitude = 22.001191 },
                    new BasicGeoposition() { Latitude = 50.035955, Longitude = 22.000929 },
                    new BasicGeoposition() { Latitude = 50.035483, Longitude = 22.000900 },
                    new BasicGeoposition() { Latitude = 50.034687, Longitude = 22.001052 },
                    new BasicGeoposition() { Latitude = 50.034408, Longitude = 22.001018 }
                }),
                StrokeColor = Colors.RoyalBlue,
                StrokeThickness = 5
            };
            Map.MapElements.Add(line);
        }

        private void AddPolygon()
        {
            MapPolygon polygon = new MapPolygon()
            {
                Path = new Geopath(new List<BasicGeoposition>()
                {
                    new BasicGeoposition() { Latitude = 50.032739, Longitude = 22.000116 },
                    new BasicGeoposition() { Latitude = 50.032135, Longitude = 22.000277 },
                    new BasicGeoposition() { Latitude = 50.032232, Longitude = 22.001163 },
                    new BasicGeoposition() { Latitude = 50.032846, Longitude = 22.001002 }
                }),
                FillColor = Colors.WhiteSmoke,
                StrokeColor = Colors.Orange,
                StrokeThickness = 3,
                StrokeDashed = true
            };
            Map.MapElements.Add(polygon);
        }
    }
}
