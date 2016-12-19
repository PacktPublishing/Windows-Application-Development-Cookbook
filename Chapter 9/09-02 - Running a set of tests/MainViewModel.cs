/*
    Exemplary file for Chapter 9 - Testing and Submission.
    Recipe: Running a set of tests.
*/

using CH09.Models;
using PropertyChanged;
using System.Windows.Input;

namespace CH09.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public float Distance { get; set; } = 0.0f;
        public float Fuel { get; set; } = 0.0f;
        public ConsumptionCalculator Calculator { get; set; }
        public ICommand CmdAdd { get; set; }

        public MainViewModel()
        {
            Calculator = new ConsumptionCalculator();
            CmdAdd = new RelayCommand(() => Calculator.Add(Distance, Fuel));
        }

        public void DeleteConsumption(Consumption consumption)
        {
            Calculator.Delete(consumption);
        }
    }
}
