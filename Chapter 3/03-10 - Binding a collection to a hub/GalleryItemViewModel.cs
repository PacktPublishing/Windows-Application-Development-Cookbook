/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a collection to a hub.
*/

using PropertyChanged;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class GalleryItemViewModel
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
