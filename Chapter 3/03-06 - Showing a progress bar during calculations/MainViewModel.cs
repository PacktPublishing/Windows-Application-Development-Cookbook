/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Showing a progress bar during calculations.
*/

using PropertyChanged;
using System.Threading.Tasks;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public bool IsCompleted { get; set; }

        public async Task Calculate()
        {
            await Task.Delay(5000);
            IsCompleted = true;
        }
    }
}
