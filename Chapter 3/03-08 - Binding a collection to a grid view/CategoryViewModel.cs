/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a collection to a grid view.
*/

using PropertyChanged;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string IconUrl { get; set; }
    }
}
