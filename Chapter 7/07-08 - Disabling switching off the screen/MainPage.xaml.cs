/*
    Exemplary file for Chapter 7 - Built-in Sensors.
    Recipe: Disabling switching off the screen.
*/

using Windows.System.Display;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CH07
{
    public sealed partial class MainPage : Page
    {
        private DisplayRequest _displayRequest;
        private bool _isRequested = false;

        public MainPage()
        {
            InitializeComponent();
            _displayRequest = new DisplayRequest();
        }

        private void BtnToggle_Click(object sender, RoutedEventArgs e)
        {
            if (_isRequested)
            {
                _displayRequest.RequestRelease();
                Page.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                _displayRequest.RequestActive();
                Page.Background = new SolidColorBrush(Colors.Yellow);
            }
            _isRequested = !_isRequested;
        }
    }
}
