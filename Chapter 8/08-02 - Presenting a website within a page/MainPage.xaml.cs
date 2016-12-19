/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Presenting a website within a page.
*/

using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CH08
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Web.Navigate(new Uri("http://jamro.biz"));
        }

        private void Web_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            if (!args.Uri.AbsoluteUri.StartsWith("http://jamro.biz"))
            {
                args.Cancel = true;
            }
        }

        private void Web_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            TxtAddress.Text = args.Uri.AbsoluteUri;
            TxtAddress.Foreground = new SolidColorBrush(args.IsSuccess ? Colors.Black : Colors.Red);
        }
    }
}
