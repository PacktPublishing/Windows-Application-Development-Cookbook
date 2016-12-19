/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Selecting data from a SQLite database.
*/

using SQLite.Net.Attributes;

namespace CH04.Models
{
    [Table("categories")]
    public class Category
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
