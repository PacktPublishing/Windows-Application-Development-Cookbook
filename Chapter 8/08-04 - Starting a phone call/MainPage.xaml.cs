/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Starting a phone call.
*/

using System;
using Windows.ApplicationModel.Calls;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH08
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnCall_Click(object sender, RoutedEventArgs e)
        {
            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            {
                PhoneCallManager.ShowPhoneCallUI("+48 000-000-000", "Marcin Jamro");
            }
            else
            {
                ContentDialog dialog = new ContentDialog()
                {
                    Content = "We are sorry, but the device does not support calling.",
                    PrimaryButtonText = "OK"
                };
                await dialog.ShowAsync();
            }
        }
    }
}
