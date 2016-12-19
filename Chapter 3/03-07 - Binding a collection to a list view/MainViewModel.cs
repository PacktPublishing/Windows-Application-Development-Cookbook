/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a collection to a list view.
*/

using PropertyChanged;
using System;
using System.Collections.Generic;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public List<UserViewModel> Users { get; set; }

        public void LoadData()
        {
            Users = new List<UserViewModel>()
            {
                new UserViewModel()
                {
                    Name = "Marcin",
                    BirthDate = new DateTime(1988, 11, 9),
                    Location = "Poland"
                },
                new UserViewModel()
                {
                    Name = "Kelly",
                    BirthDate = new DateTime(1990, 5, 5),
                    Location = "England"
                },
                new UserViewModel()
                {
                    Name = "Thomas",
                    BirthDate = new DateTime(1985, 1, 5),
                    Location = "Germany"
                },
                new UserViewModel()
                {
                    Name = "Ann",
                    BirthDate = new DateTime(1991, 7, 11),
                    Location = "Slovakia"
                },
                new UserViewModel()
                {
                    Name = "John",
                    BirthDate = new DateTime(1976, 8, 1),
                    Location = "Hungary"
                }
            };
        }
    }
}
