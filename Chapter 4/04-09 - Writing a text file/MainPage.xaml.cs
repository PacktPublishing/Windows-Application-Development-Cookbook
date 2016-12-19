/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Writing a text file.
*/

using System;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH04
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync("Note.txt", CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(file, TxtNote.Text);
        }
    }
}
