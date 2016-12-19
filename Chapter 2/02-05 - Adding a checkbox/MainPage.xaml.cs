/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Adding a checkbox.
*/

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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
        }
    }
}
