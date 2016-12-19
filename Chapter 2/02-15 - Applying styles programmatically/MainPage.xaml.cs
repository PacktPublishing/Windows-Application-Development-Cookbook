/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Applying styles programmatically.
*/

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CH02
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BorImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Style styleInactive = (Style)Resources["BorImageInactive"];
            Style styleActive = (Style)Resources["BorImageActive"];
            Border border = (Border)sender;
            border.Style = border.Style == styleInactive ? styleActive : styleInactive;
        }
    }
}
