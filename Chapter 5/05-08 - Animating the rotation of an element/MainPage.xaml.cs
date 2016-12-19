/*
    Exemplary file for Chapter 5 - Animations and Graphics.
    Recipe: Animating the rotation of an element.
*/

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CH05
{
    public sealed partial class MainPage : Page
    {
        private bool _isRunning = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (_isRunning)
            {
                ImageRotate.Stop();
            }
            else
            {
                ImageRotate.Begin();
            }

            _isRunning = !_isRunning;
        }
    }
}
