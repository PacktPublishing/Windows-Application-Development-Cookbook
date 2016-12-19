/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Playing an audio file.
*/

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CH06
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (Audio.CurrentState == MediaElementState.Playing)
            {
                BtnPlay.Content = "Continue";
                Audio.Pause();
            }
            else
            {
                BtnPlay.Content = "Pause";
                Audio.Play();
            }
        }
    }
}
