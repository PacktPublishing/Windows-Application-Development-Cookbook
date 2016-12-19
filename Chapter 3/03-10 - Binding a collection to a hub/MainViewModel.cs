/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a collection to a hub.
*/

using PropertyChanged;
using System.Collections.Generic;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public List<GalleryItemViewModel> Items { get; set; }

        public void LoadData()
        {
            Items = new List<GalleryItemViewModel>()
            {
                new GalleryItemViewModel()
                {
                    Title = "Picture Lake",
                    ImageUrl = "ms-appx:///Assets/G01.jpg"
                },
                new GalleryItemViewModel()
                {
                    Title = "Canyon Road",
                    ImageUrl = "ms-appx:///Assets/G02.jpg"
                },
                new GalleryItemViewModel()
                {
                    Title = "Hiking to Angels' Landing",
                    ImageUrl = "ms-appx:///Assets/G03.jpg"
                },
                new GalleryItemViewModel()
                {
                    Title = "Grand Canyon",
                    ImageUrl = "ms-appx:///Assets/G04.jpg"
                }
            };
        }
    }
}
