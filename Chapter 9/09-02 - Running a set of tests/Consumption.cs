/*
    Exemplary file for Chapter 9 - Testing and Submission.
    Recipe: Running a set of tests.
*/

using PropertyChanged;

namespace CH09.Models
{
    [ImplementPropertyChanged]
    public class Consumption
    {
        public float Distance { get; set; }
        public float Fuel { get; set; }
    }
}
