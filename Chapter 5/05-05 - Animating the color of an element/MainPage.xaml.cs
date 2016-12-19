/*
    Exemplary file for Chapter 5 - Animations and Graphics.
    Recipe: Animating the color of an element.
*/

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CH05
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            HeaderStart.Begin();
        }
    }
}
