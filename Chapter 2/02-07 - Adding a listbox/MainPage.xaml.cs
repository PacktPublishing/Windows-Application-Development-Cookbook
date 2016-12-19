/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Adding a listbox.
*/

using Windows.UI.Xaml.Controls;

namespace CH02
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            int selectedIndex = listBox.SelectedIndex;
            ListBoxItem selectedItem = (ListBoxItem)listBox.SelectedItem;
            string selectedTag = (string)selectedItem.Tag;
            switch (selectedTag)
            {
                case "PL": /* ... */ break;
                case "EN": /* ... */ break;
                case "DE": /* ... */ break;
            }
        }
    }
}
