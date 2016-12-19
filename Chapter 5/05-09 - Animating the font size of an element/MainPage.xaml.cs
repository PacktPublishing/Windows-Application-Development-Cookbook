/*
    Exemplary file for Chapter 5 - Animations and Graphics.
    Recipe: Animating the font size of an element.
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

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            HeaderChangeSize.Begin();
        }
    }
}
