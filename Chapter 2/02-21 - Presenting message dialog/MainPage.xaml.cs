/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Presenting message dialog.
*/

using System;
using System.Threading.Tasks;
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

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog(
               "Are you sure that you want to delete this entry?",
               "Confirmation");
            dialog.Commands.Add(new UICommand("Yes", DeleteConfirmed));
            dialog.Commands.Add(new UICommand("No"));
            await dialog.ShowAsync();
        }

        private async void DeleteConfirmed(IUICommand command)
        {
            await Task.Delay(1000);
            MessageDialog dialog = new MessageDialog(
               "The entry has been removed successfully!",
               "Confirmation");
            dialog.Commands.Add(new UICommand("OK"));
            await dialog.ShowAsync();
        }
    }
}
