/*
    Exemplary file for Chapter 3 - MVVM and Data Binding.
    Recipe: Introducing bindings and commands.
*/

using CH03.Models;
using PropertyChanged;
using System.Windows.Input;

namespace CH03.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public const string GUEST_NAME = "Guest";
        public const string USER_NAME = "Marcin";
        public const string BTN_TEXT_LOG_IN = "Log in";
        public const string BTN_TEXT_LOG_OUT = "Log out";
        public const string BTN_COLOR_LOG_IN = "#a1ef92";
        public const string BTN_COLOR_LOG_OUT = "#f17272";

        public string UserName { get; set; } = GUEST_NAME;
        public string ButtonText { get; set; } = BTN_TEXT_LOG_IN;
        public string ButtonColor { get; set; } = BTN_COLOR_LOG_IN;
        public ICommand CmdLogInOut { get; set; }

        public MainViewModel()
        {
            CmdLogInOut = new RelayCommand(() => LogInOut());
        }

        private void LogInOut()
        {
            if (UserName == GUEST_NAME)
            {
                ButtonColor = BTN_COLOR_LOG_OUT;
                ButtonText = BTN_TEXT_LOG_OUT;
                UserName = USER_NAME;
            }
            else
            {
                ButtonColor = BTN_COLOR_LOG_IN;
                ButtonText = BTN_TEXT_LOG_IN;
                UserName = GUEST_NAME;
            }
        }
    }
}
