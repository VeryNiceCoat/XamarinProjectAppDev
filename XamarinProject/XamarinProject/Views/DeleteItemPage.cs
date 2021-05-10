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
    public class DeleteItemPage : ContentPage
    {
        private ListView _listView;
        private Button _button;

        Item _item = new Item();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public DeleteItemPage()
        {
            this.Title = "Edit Items";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Item>().OrderBy(x => x.name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Delete";
            _button.Clicked += button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _item = (Item)e.SelectedItem;
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Item>().Delete(x => x.Id == _item.Id);
            await Navigation.PopAsync();
        }
    }

}
