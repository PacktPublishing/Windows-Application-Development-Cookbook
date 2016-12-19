/*
    Exemplary file for Chapter 6 - Multimedia.
    Recipe: Preparing a photo album with captions.
*/

using PropertyChanged;

namespace CH06.ViewModels
{
    [ImplementPropertyChanged]
    public class PhotoViewModel
    {
        public string Url { get; set; }
        public string Caption { get; set; }
    }
}
