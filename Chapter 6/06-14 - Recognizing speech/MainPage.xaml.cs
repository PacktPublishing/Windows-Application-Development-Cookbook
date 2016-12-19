/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Recognizing speech.
*/

using System;
using System.Collections.Generic;
using Windows.Media.SpeechRecognition;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CH06
{
    public sealed partial class MainPage : Page
    {
        private SpeechRecognizer _recognizer = null;

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _recognizer = new SpeechRecognizer();
            List<string> phrases = new List<string>() { "red", "yellow", "white", "blue", "green" };
            SpeechRecognitionListConstraint listConstraint = new SpeechRecognitionListConstraint(phrases);
            _recognizer.Constraints.Add(listConstraint);
            await _recognizer.CompileConstraintsAsync();
        }

        private async void GrdMain_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SpeechRecognitionResult result = await _recognizer.RecognizeWithUIAsync();
            if (result.Status == SpeechRecognitionResultStatus.Success)
            {
                GrdMain.Background = new SolidColorBrush(GetColor(result.Text));
            }
        }

        private Color GetColor(string color)
        {
            switch (color)
            {
                case "red": return Colors.Red;
                case "yellow": return Colors.Yellow;
                case "white": return Colors.White;
                case "blue": return Colors.Blue;
                case "green": return Colors.Green;
                default: return Colors.Black;
            }
        }
    }
}
