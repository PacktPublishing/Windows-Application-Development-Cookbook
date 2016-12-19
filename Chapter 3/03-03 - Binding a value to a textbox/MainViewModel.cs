/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Binding a value to a textbox.
*/

using PropertyChanged;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public string UserName { get; set; } = "";

        [DependsOn("UserName")]
        public string UserNameUpper
        {
            get { return UserName.ToUpper(); }
        }

        [DependsOn("UserName")]
        public string UserNameLower
        {
            get { return UserName.ToLower(); }
        }

        [DependsOn("UserName")]
        public string UserNameReversed
        {
            get
            {
                string reversed = string.Empty;
                for (int i = UserName.Length - 1; i >= 0; i--)
                {
                    reversed += UserName[i];
                }
                return reversed;
            }
        }
    }
}
