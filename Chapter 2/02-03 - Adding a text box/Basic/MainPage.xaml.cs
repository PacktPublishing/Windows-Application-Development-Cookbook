/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Adding a text box.
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
        }

        private void TextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            string text = sender.Text;
        }
    }
}
