/*
    Exemplary file for Chapter 7 - Built-in Sensors.
    Recipe: Reading NFC tags.
*/

using System;
using Windows.Networking.Proximity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CH07
{
    public sealed partial class MainPage : Page
    {
        private long _subscriptionId;
        private ProximityDevice _proximity;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (_subscriptionId > 0)
            {
                _proximity.StopSubscribingForMessage(_subscriptionId);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _proximity = ProximityDevice.GetDefault();
            if (_proximity != null)
            {
                _subscriptionId = _proximity.SubscribeForMessage("NDEF", TagRead);
            }
        }

        private async void TagRead(ProximityDevice sender, ProximityMessage message)
        {
            string uri = message.DataAsString.Replace("\0", "");
            if (uri.StartsWith("http://") || uri.StartsWith("https://"))
            {
                await Dispatcher.RunAsync(
                    Windows.UI.Core.CoreDispatcherPriority.Normal,
                    () =>
                    {
                        Website.Navigate(new Uri(uri));
                        Information.Visibility = Visibility.Collapsed;
                    });
            }
        }
    }
}
