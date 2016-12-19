/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Adding a combobox.
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int selectedIndex = comboBox.SelectedIndex;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string selectedTag = (string)selectedItem.Tag;
        }
    }
}
