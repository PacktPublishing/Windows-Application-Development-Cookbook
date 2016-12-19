/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Choosing a file to save.
*/

using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH06
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnChoose_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker picker = new FileSavePicker();
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.SuggestedFileName = "Notes";
            picker.FileTypeChoices.Add("Text file", new List<string>() { ".txt" });
            StorageFile file = await picker.PickSaveFileAsync();
            if (file != null)
            {
                string content = string.Format("Today is {0}.", DateTime.Now.DayOfWeek);
                await FileIO.WriteTextAsync(file, content);
            }
        }
    }
}
