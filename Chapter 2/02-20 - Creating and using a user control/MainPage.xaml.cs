/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Creating and using a user control.
*/

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
                
        private void TilFavorites_Tapped(object sender, TappedRoutedEventArgs e)
        {
        }

        private void TilSettings_Tapped(object sender, TappedRoutedEventArgs e)
        {
        }
    }
}
