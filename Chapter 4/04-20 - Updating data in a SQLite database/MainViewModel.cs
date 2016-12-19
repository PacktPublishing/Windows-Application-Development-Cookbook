/*
    Exemplary file for Chapter 4 - Data Storage.
    Recipe: Updating data in a SQLite database.
*/

using CH04.Models;
using PropertyChanged;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Windows.Storage;
using System.Linq;
using System;
using System.Windows.Input;

namespace CH04.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        private int _entryId = 0;
        public string Title { get; set; }
        public string Content { get; set; }
        public EntryViewModel Entry { get; set; }
        public ICommand CmdSave { get; set; }
        public ICommand CmdAdd { get; set; }
        public ICommand CmdEdit { get; set; }

        [DependsOn("Entries")]
        public bool IsEntrySelected
        {
            get { return Entry != null; }
        }

        public CategoryViewModel Category { get; set; }
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public ObservableCollection<EntryViewModel> Entries { get; set; }

        public MainViewModel()
        {
            Categories = new ObservableCollection<CategoryViewModel>();
            Entries = new ObservableCollection<EntryViewModel>();
            CmdSave = new RelayCommand(() => Save());
            CmdAdd = new RelayCommand(() => LaunchAddMode());
            CmdEdit = new RelayCommand(() => LaunchEditMode());
        }

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

        public void LoadCategories()
        {
            Categories.Clear();
            using (SQLiteConnection connection = GetConnection())
            {
                List<Category> categoriesDB = connection.Table<Category>().OrderBy(c => c.Name).ToList();
                foreach (Category categoryDB in categoriesDB)
                {
                    CategoryViewModel category = new CategoryViewModel()
                    {
                        Id = categoryDB.Id,
                        Name = categoryDB.Name
                    };
                    Categories.Add(category);
                }
                Category = Categories[0];
            }
        }

        public void LoadEntries()
        {
            Entries.Clear();
            using (SQLiteConnection connection = GetConnection())
            {
                List<Entry> entriesDB = connection.Table<Entry>().OrderByDescending(e => e.Id).ToList();
                foreach (Entry entryDB in entriesDB)
                {
                    EntryViewModel entry = new EntryViewModel()
                    {
                        Id = entryDB.Id,
                        Title = entryDB.Title,
                        Content = entryDB.Content,
                        Category = Categories.SingleOrDefault(c => c.Id == entryDB.CategoryId)
                    };
                    Entries.Add(entry);
                }
            }
        }

        private void LaunchAddMode()
        {
            _entryId = 0;
            Title = string.Empty;
            Content = string.Empty;
            Category = Categories[0];
        }

        private void LaunchEditMode()
        {
            _entryId = Entry.Id;
            Title = Entry.Title;
            Content = Entry.Content;
            Category = Entry.Category;
        }

        private void Save()
        {
            using (SQLiteConnection connection = GetConnection())
            {
                Entry entry = null;

                if (_entryId != 0)
                {
                    entry = connection.Get<Entry>(_entryId);
                    entry.EditedAt = DateTime.Now;
                }
                else
                {
                    entry = new Entry();
                    entry.AddedAt = DateTime.Now;
                }

                entry.Title = Title;
                entry.Content = Content;
                entry.CategoryId = Category.Id;

                if (_entryId != 0)
                {
                    connection.Update(entry);
                }
                else
                {
                    connection.Insert(entry);
                }
            }

            LoadEntries();
            LaunchAddMode();
        }

        private SQLiteConnection GetConnection()
        {
            string dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            return new SQLiteConnection(new SQLitePlatformWinRT(), dbPath);
        }
    }
}
