/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a collection to a grid view.
*/

using PropertyChanged;
using System.Collections.ObjectModel;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        public void LoadData()
        {
            Categories = new ObservableCollection<CategoryViewModel>()
            {
                new CategoryViewModel()
                {
                    Id = 1,
                    Name = "Country",
                    Count = 8,
                    IconUrl = "ms-appx:///Assets/Country.png"
                },
                new CategoryViewModel()
                {
                    Id = 2,
                    Name = "World",
                    Count = 12,
                    IconUrl = "ms-appx:///Assets/World.png"
                },
                new CategoryViewModel()
                {
                    Id = 3,
                    Name = "Local",
                    Count = 3,
                    IconUrl = "ms-appx:///Assets/Local.png"
                },
                new CategoryViewModel()
                {
                    Id = 4,
                    Name = "Culture",
                    Count = 8,
                    IconUrl = "ms-appx:///Assets/Culture.png"
                },
                new CategoryViewModel()
                {
                    Id = 5,
                    Name = "Sport",
                    Count = 4,
                    IconUrl = "ms-appx:///Assets/Sport.png"
                },
                new CategoryViewModel()
                {
                    Id = 6,
                    Name = "Government",
                    Count = 5,
                    IconUrl = "ms-appx:///Assets/Gov.png"
                }
            };
        }
    }
}
