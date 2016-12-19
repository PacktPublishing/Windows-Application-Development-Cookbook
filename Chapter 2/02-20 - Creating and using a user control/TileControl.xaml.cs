/*
	Exemplary file for Chapter 2 - Designing a User Interface.
    Recipe: Creating and using a user control.
*/

using PropertyChanged;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CH02
{
    [ImplementPropertyChanged]
    public sealed partial class TileControl : UserControl
    {
        public SolidColorBrush TileBackground { get; set; }
        public SolidColorBrush TileForeground { get; set; }
        public string IconUrl { get; set; }
        public string Title { get; set; }

        public TileControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
