/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Preparing a photo album with captions.
*/

using PropertyChanged;
using System.Collections.Generic;

namespace CH06.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public List<PhotoViewModel> Photos { get; set; }
    }
}
