/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Creating a SQLite database and tables.
*/

using SQLite.Net.Attributes;
using System;

namespace CH04.Models
{
    [Table("entries")]
    public class Entry
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime? EditedAt { get; set; }
    }
}
