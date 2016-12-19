/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a colection to a combobox.
*/

using PropertyChanged;
using System.Collections.Generic;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public LanguageViewModel CurrentLanguage { get; set; }
        public List<LanguageViewModel> Languages { get; set; }

        public void LoadData()
        {
            Languages = new List<LanguageViewModel>()
            {
                new LanguageViewModel()
                {
                    Code = "DE",
                    Name = "German",
                    IconUrl = "ms-appx:///Assets/FlagDE.png"
                },
                new LanguageViewModel()
                {
                    Code = "EN",
                    Name = "English",
                    IconUrl = "ms-appx:///Assets/FlagEN.png"
                },
                new LanguageViewModel()
                {
                    Code = "FR",
                    Name = "French",
                    IconUrl = "ms-appx:///Assets/FlagFR.png"
                },
                new LanguageViewModel()
                {
                    Code = "JP",
                    Name = "Japanese",
                    IconUrl = "ms-appx:///Assets/FlagJP.png"
                },
                new LanguageViewModel()
                {
                    Code = "PL",
                    Name = "Polish",
                    IconUrl = "ms-appx:///Assets/FlagPL.png"
                }
            };
            CurrentLanguage = Languages[1];
        }
    }
}
