/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Creating a SQLite database and tables.
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
