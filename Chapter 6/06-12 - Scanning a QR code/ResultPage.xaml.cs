/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Scanning a QR code.
*/

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CH06
{
    public sealed partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string result = (string)e.Parameter;
            Code.Text = result;
        }
    }
}
