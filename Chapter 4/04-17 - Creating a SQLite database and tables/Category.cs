/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Creating a SQLite database and tables.
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
