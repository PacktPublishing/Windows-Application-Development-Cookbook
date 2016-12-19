/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Synthesizing speech.
*/

using System;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CH06
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            SpeechSynthesisStream stream = await synthesizer.SynthesizeTextToStreamAsync("Hello, dear reader! How are you?");
            MediaElement audio = new MediaElement();
            audio.SetSource(stream, stream.ContentType);
            audio.Play();
        }
    }
}
