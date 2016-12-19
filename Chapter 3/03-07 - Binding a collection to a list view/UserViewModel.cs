/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a collection to a list view.
*/

using PropertyChanged;
using System;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime BirthDate { get; set; }

        [DependsOn("BirthDate")]
        public int DaysToBirthday
        {
            get
            {
                DateTime thisYearBirthday = new DateTime(DateTime.Now.Year, BirthDate.Month, BirthDate.Day);
                int remainingDays = (int)(thisYearBirthday - DateTime.Now.Date).TotalDays;
                if (remainingDays >= 0)
                {
                    return remainingDays;
                }
                else
                {
                    DateTime nextYearBirthday = new DateTime(DateTime.Now.Year + 1, BirthDate.Month, BirthDate.Day);
                    return (int)(nextYearBirthday - DateTime.Now.Date).TotalDays;
                }
            }
        }
    }
}
