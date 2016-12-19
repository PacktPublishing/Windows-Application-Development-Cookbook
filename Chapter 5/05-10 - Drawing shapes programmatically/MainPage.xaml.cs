/*
    Exemplary file for Chapter 5 - Animations and Graphics.
    Recipe: Drawing shapes programmatically.
*/

using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CH05
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DrawRectangle();
            DrawEllipse();
            DrawPolygon();
            DrawPolyline();
            DrawLines();
        }

        private void DrawRectangle()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new SolidColorBrush(Colors.GreenYellow);
            rectangle.Width = 100;
            rectangle.Height = 100;
            rectangle.RadiusX = 25;
            rectangle.RadiusY = 25;
            rectangle.SetValue(Canvas.LeftProperty, 50);
            rectangle.SetValue(Canvas.TopProperty, 50);
            rectangle.Stroke = new SolidColorBrush(Colors.DarkGreen);
            rectangle.StrokeThickness = 5;
            Canvas.Children.Add(rectangle);
        }

        private void DrawEllipse()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = new SolidColorBrush(Colors.RoyalBlue);
            ellipse.Width = 100;
            ellipse.Height = 100;
            ellipse.SetValue(Canvas.LeftProperty, 200);
            ellipse.SetValue(Canvas.TopProperty, 50);
            ellipse.Stroke = new SolidColorBrush(Colors.DarkBlue);
            ellipse.StrokeThickness = 5;
            Canvas.Children.Add(ellipse);
        }

        private void DrawPolygon()
        {
            Polygon polygon = new Polygon();
            polygon.Fill = new SolidColorBrush(Colors.IndianRed);
            polygon.Points = new PointCollection()
            {
                new Point(0, 100),
                new Point(100, 100),
                new Point(50, 0)
            };
            polygon.SetValue(Canvas.LeftProperty, 350);
            polygon.SetValue(Canvas.TopProperty, 50);
            polygon.Stroke = new SolidColorBrush(Colors.DarkRed);
            polygon.StrokeThickness = 5;
            Canvas.Children.Add(polygon);
        }

        private void DrawPolyline()
        {
            Polyline polyline = new Polyline();
            polyline.Points = new PointCollection()
            {
                new Point(0, 100),
                new Point(50, 0),
                new Point(100, 100)
            };
            polyline.SetValue(Canvas.LeftProperty, 50);
            polyline.SetValue(Canvas.TopProperty, 200);
            polyline.Stroke = new SolidColorBrush(Colors.DarkMagenta);
            polyline.StrokeThickness = 5;
            Canvas.Children.Add(polyline);
        }

        private void DrawLines()
        {
            for (int x = 0; x < 300; x += 50)
            {
                Line line = new Line();
                line.X1 = x;
                line.X2 = x + 25;
                line.Y1 = 50;
                line.Y2 = 50;
                line.SetValue(Canvas.LeftProperty, 200);
                line.SetValue(Canvas.TopProperty, 200);
                line.Stroke = new SolidColorBrush(Colors.Orange);
                line.StrokeThickness = 5;
                Canvas.Children.Add(line);
            }
        }
    }
}
