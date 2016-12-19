/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Localizing content programmatically.
*/

using System;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH02
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ResourceLoader loader = new ResourceLoader();
            MessageDialog dialog = new MessageDialog(
                loader.GetString("EntryAddedMessageContent"),
                loader.GetString("EntryAddedMessageTitle"));
            dialog.Commands.Add(new UICommand(loader.GetString("OK")));
            await dialog.ShowAsync();
        }
    }
}
