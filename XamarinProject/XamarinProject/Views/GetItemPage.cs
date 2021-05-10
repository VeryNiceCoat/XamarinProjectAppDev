using System;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinProject.Models;

namespace XamarinProject.Views
{
    public class GetItemPage : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public GetItemPage()
        {
            this.Title = "Items";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Item>().OrderBy(x => x.name).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}