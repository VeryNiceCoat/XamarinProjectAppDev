using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;

using Xamarin.Forms;
using XamarinProject.Models;

namespace XamarinProject.Views
{
    public class EditItemPage : ContentPage
    {
        private ListView _listView;
        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _priceEntry;
        private Button _button;

        Item _item = new Item();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public EditItemPage()
        {
            this.Title = "Edit Items";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Item>().OrderBy(x => x.name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nameEntry = new Entry();
            _nameEntry.Placeholder = "Item Name";
            _nameEntry.Keyboard = Keyboard.Text;
            stackLayout.Children.Add(_nameEntry);

            _priceEntry = new Entry();
            _priceEntry.Placeholder = "Price";
            _priceEntry.Keyboard = Keyboard.Text;
            stackLayout.Children.Add(_priceEntry);

            _button = new Button();
            _button.Text = "Update";
            _button.Clicked += button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Item item = new Item();
            {
                item.Id = Convert.ToInt32(_idEntry.Text);
                item.name = _nameEntry.Text;
                item.price = _priceEntry.Text;
            };

            db.Update(item);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _item = (Item)e.SelectedItem;
            _idEntry.Text = _item.Id.ToString();
            _nameEntry.Text = _item.name;
            _priceEntry.Text = _item.price;
        }
    }
}