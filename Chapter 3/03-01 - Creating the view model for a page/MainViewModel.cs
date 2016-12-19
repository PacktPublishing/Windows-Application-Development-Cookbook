/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Creating the view model for a page.
*/

using PropertyChanged;
using System;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public string FirstName { get; set; } = "Marcin";
        public string LastName { get; set; } = "Jamro";
        public DateTime BirthDate { get; set; } = new DateTime(1988, 11, 9);
        public bool AreRulesAccepted { get; set; } = false;
    }
}
