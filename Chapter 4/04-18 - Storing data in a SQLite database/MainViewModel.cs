/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Storing data in a SQLite database.
*/

using CH04.Models;
using PropertyChanged;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.Storage;

namespace CH04.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public void InitializeDatabase()
        {
            using (SQLiteConnection connection = GetConnection())
            {
                if (connection.GetTableInfo("categories").Count == 0)
                {
                    connection.CreateTable<Category>();
                    connection.CreateTable<Entry>();
                    Category[] categories =
                    {
                        new Category() { Name = "Private" },
                        new Category() { Name = "Hobby" },
                        new Category() { Name = "Sport" }
                    };
                    connection.InsertAll(categories);
                }
            }
        }

        private SQLiteConnection GetConnection()
        {
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            return new SQLiteConnection(new SQLitePlatformWinRT(), dbPath);
        }
    }
}
