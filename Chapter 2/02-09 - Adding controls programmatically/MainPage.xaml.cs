/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Adding controls programmatically.
*/

using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CH02
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            Button button = new Button()
            {
                Content = "Click me!",
                Background = new SolidColorBrush(Colors.LightGray),
                Foreground = new SolidColorBrush(Colors.RoyalBlue),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                BorderBrush = new SolidColorBrush(Colors.RoyalBlue),
                BorderThickness = new Thickness(3),
                FontSize = 20
            };
            button.Click += Button_Click;
            Grid.Children.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)Grid.Children[0];
            button.Background = new SolidColorBrush(Colors.Red);
            button.Foreground = new SolidColorBrush(Colors.White);
            button.BorderBrush = new SolidColorBrush(Colors.Black);
        }
    }
}
