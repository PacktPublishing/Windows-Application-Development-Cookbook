/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Removing a file.
*/

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        private async void BtnIterateDirectories_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            List<string> paths = await GetPath(localFolder);
            TxtResult.Text = string.Join(Environment.NewLine, paths);
        }

        private async Task<List<string>> GetPath(StorageFolder folder, string path = "")
        {
            List<string> paths = new List<string>();
            if (!string.IsNullOrEmpty(path))
            {
                paths.Add(path);
            }

            IReadOnlyList<StorageFolder> subfolders = await folder.GetFoldersAsync();
            foreach (StorageFolder subfolder in subfolders)
            {
                string subpath = path;
                if (!string.IsNullOrEmpty(subpath))
                {
                    subpath += " | ";
                }

                subpath += subfolder.Name;
                paths.AddRange(await GetPath(subfolder, subpath));
            }
            return paths;
        }

        private async void BtnCreateFile_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder bookFolder = await localFolder.GetFolderAsync("Book");
            StorageFile notesFile = await bookFolder.CreateFileAsync("Notes.txt", CreationCollisionOption.OpenIfExists);
            StorageFile imageFile = await bookFolder.CreateFileAsync("Image.png", CreationCollisionOption.OpenIfExists);
            StorageFile movieFile = await bookFolder.CreateFileAsync("Movie.mp4", CreationCollisionOption.OpenIfExists);
        }

        private async void BtnIterateFiles_Click(object sender, RoutedEventArgs e)
        {
            List<string> fileNames = new List<string>();
            StorageFolder bookFolder = await ApplicationData.Current.LocalFolder.GetFolderAsync("Book");
            foreach (StorageFile file in await bookFolder.GetFilesAsync())
            {
                fileNames.Add(file.Name);
            }

            TxtResult.Text = string.Join(Environment.NewLine, fileNames);
        }

        private async void BtnRenameDirectory_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder bookFolder = (StorageFolder)await ApplicationData.Current.LocalFolder.TryGetItemAsync("Book");
            if (bookFolder != null)
            {
                try
                {
                    await bookFolder.RenameAsync("New book");
                }
                catch (Exception)
                {
                    TxtResult.Text = "Renaming has failed!";
                }
            }
            else
            {
                TxtResult.Text = "The directory does not exist!";
            }
        }

        private async void BtnRenameFile_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder bookFolder = (StorageFolder)await ApplicationData.Current.LocalFolder.TryGetItemAsync("Book");
            if (bookFolder != null)
            {
                StorageFile notesFile = (StorageFile)await bookFolder.TryGetItemAsync("Notes.txt");
                if (notesFile != null)
                {
                    try
                    {
                        await notesFile.RenameAsync("Note.txt");
                    }
                    catch (Exception)
                    {
                        TxtResult.Text = "Renaming has failed!";
                    }
                }
                else
                {
                    TxtResult.Text = "The file does not exist!";
                }
            }
            else
            {
                TxtResult.Text = "The directory does not exist!";
            }
        }

        private async void BtnDeleteDirectory_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder bookFolder = (StorageFolder)await ApplicationData.Current.LocalFolder.TryGetItemAsync("Book");
            if (bookFolder != null)
            {
                await bookFolder.DeleteAsync();
            }
            else
            {
                TxtResult.Text = "The directory does not exist!";
            }
        }

        private async void BtnDeleteFile_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder bookFolder = (StorageFolder)await ApplicationData.Current.LocalFolder.TryGetItemAsync("Book");
            if (bookFolder != null)
            {
                StorageFile notesFile = (StorageFile)await bookFolder.TryGetItemAsync("Notes.txt");
                if (notesFile != null)
                {
                    await notesFile.DeleteAsync();
                }
                else
                {
                    TxtResult.Text = "The file does not exist!";
                }
            }
            else
            {
                TxtResult.Text = "The directory does not exist!";
            }
        }
    }
}
