/*
    Exemplary file for Chapter 9 - Testing and Submission.
    Recipe: Running a set of tests.
*/

using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CH09.Models
{
    [ImplementPropertyChanged]
    public class ConsumptionCalculator
    {
        public ObservableCollection<Consumption> Consumptions { get; private set; }
        public float Average { get; private set; }

        public ConsumptionCalculator()
        {
            Consumptions = new ObservableCollection<Consumption>();
        }

        public void Add(float distance, float fuel)
        {
            if (distance > 0 && fuel > 0)
            {
                Consumption consumption = new Consumption()
                {
                    Distance = distance,
                    Fuel = fuel
                };
                Consumptions.Add(consumption);
                CalculateAverage();
            }
        }

        public void Delete(Consumption consumption)
        {
            Consumptions.Remove(consumption);
            CalculateAverage();
        }

        public void CalculateAverage()
        {
            float distance = Consumptions.Sum(c => c.Distance);
            float fuel = Consumptions.Sum(c => c.Fuel);
            float average = 0.0f;
            if (distance > 0.0f)
            {
                average = (fuel * 100) / distance;
            }
            Average = (float)Math.Round(average, 2);
        }
    }
}
