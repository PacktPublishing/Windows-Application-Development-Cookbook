/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Creating a directory.
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

        private async void BtnCreateDirectory_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder bookFolder = await localFolder.CreateFolderAsync("Book", CreationCollisionOption.OpenIfExists);
            StorageFolder workFolder = await localFolder.CreateFolderAsync("Work", CreationCollisionOption.OpenIfExists);
            await bookFolder.CreateFolderAsync("Chapter 1", CreationCollisionOption.OpenIfExists);
            await bookFolder.CreateFolderAsync("Chapter 2", CreationCollisionOption.OpenIfExists);
            await bookFolder.CreateFolderAsync("Chapter 3", CreationCollisionOption.OpenIfExists);
            StorageFolder chapterFolder = await bookFolder.CreateFolderAsync("Chapter 4", CreationCollisionOption.OpenIfExists);
            await chapterFolder.CreateFolderAsync("Images", CreationCollisionOption.OpenIfExists);
            await chapterFolder.CreateFolderAsync("Codes", CreationCollisionOption.OpenIfExists);
        }
    }
}
