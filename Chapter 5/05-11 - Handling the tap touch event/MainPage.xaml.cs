/*
    Exemplary file for Chapter 5 - Animations and Graphics.
    Recipe: Handling the "tap" touch event.
*/

using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CH05
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint pressedPoint = e.GetCurrentPoint(Canvas);
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = new SolidColorBrush(Colors.RoyalBlue);
            ellipse.Width = 50;
            ellipse.Height = 50;
            ellipse.SetValue(Canvas.LeftProperty, pressedPoint.Position.X - 25);
            ellipse.SetValue(Canvas.TopProperty, pressedPoint.Position.Y - 25);
            Canvas.Children.Add(ellipse);
        }
    }
}
