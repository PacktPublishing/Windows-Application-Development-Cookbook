/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Removing data from a SQLite database.
*/

namespace CH04.ViewModels
{
    public class EntryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
