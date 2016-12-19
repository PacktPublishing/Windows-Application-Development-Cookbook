/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Writing a binary file.
*/

using CH04.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;

namespace CH04.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Average { get; set; }
        public int Count { get; set; }
        public int Time { get; set; }
        public List<ResultViewModel> Results { get; set; }
        public ICommand CmdStart { get; set; }
        public ICommand CmdSave { get; set; }

        public MainViewModel()
        {
            Results = new List<ResultViewModel>();
            CmdStart = new RelayCommand(() => Start());
            CmdSave = new RelayCommand(async () => await Save());
        }

        private void Start()
        {
            Results.Clear();
            DateTime startTime = DateTime.Now;
            Minimum = int.MaxValue;
            Maximum = int.MinValue;

            Random random = new Random();
            for (int i = 0; i < 100000; i++)
            {
                int value = random.Next();
                int time = (int)(DateTime.Now.Subtract(startTime).TotalMilliseconds);
                ResultViewModel result = new ResultViewModel()
                {
                    Value = value,
                    Time = time
                };
                Results.Add(result);
            }

            Minimum = Results.Min(r => r.Value);
            Maximum = Results.Max(r => r.Value);
            Average = (int)Results.Average(r => r.Value);
            Count = Results.Count;
            Time = Results.Last().Time;
        }

        private async Task Save()
        {
            List<byte> bytes = new List<byte>();
            foreach (ResultViewModel result in Results)
            {
                byte[] timeBytes = BitConverter.GetBytes(result.Time);
                byte[] valueBytes = BitConverter.GetBytes(result.Value);
                bytes.AddRange(timeBytes);
                bytes.AddRange(valueBytes);
            }

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync("Results.bin", CreationCollisionOption.OpenIfExists);
            await FileIO.WriteBytesAsync(file, bytes.ToArray());
        }
    }
}
