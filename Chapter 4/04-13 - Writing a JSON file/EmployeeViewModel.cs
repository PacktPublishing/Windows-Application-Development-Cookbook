/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Writing a JSON file.
*/

using PropertyChanged;
using System.Collections.Generic;

namespace CH04.ViewModels
{
    [ImplementPropertyChanged]
    public class EmployeeViewModel
    {
        public string FullName { get; set; }
        public List<string> Languages { get; set; }

        [DependsOn("Language")]
        public string LanguagesFormatted
        {
            get { return string.Join(", ", Languages); }
        }
    }
}
