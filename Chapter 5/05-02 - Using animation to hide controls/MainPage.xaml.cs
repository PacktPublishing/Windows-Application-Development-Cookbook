/*
    Exemplary file for Chapter 5 - Animations and Graphics.
    Recipe: Using animation to hide controls.
*/

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH05
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnHide_Click(object sender, RoutedEventArgs e)
        {
            HeaderHide.Begin();
        }
    }
}
