/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Writing an XML file.
*/

using System;

namespace CH04.ViewModels
{
    public class EventViewModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string DateFormatted
        {
            get { return Date.ToString("M/d/yyyy"); }
        }
    }
}
