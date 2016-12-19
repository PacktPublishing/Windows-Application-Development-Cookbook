/*
    Exemplary file for Chapter 5 - Animations and Graphics.
    Recipe: Animating repositioning of items collection.
*/

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CH05
{
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer _timer = null;

        public MainPage()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            if (Months.Items.Count > 0)
            {
                Random random = new Random();
                Months.Items.RemoveAt(random.Next(Months.Items.Count));
            }
        }
    }
}
