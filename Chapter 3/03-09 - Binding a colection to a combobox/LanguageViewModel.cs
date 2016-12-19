/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a colection to a combobox.
*/

using PropertyChanged;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class LanguageViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
    }
}
