/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Adding a password box.
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

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            string password = passwordBox.Password;
        }
    }
}
