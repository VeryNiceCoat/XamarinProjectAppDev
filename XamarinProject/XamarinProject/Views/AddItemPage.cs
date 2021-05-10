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
    public class AddItemPage : ContentPage
    {
        private Entry _nameEntry;
        private Entry _priceEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"myDB.db3");
        public AddItemPage()
        {
            this.Title = "Add Company";

            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Item Name";
            stackLayout.Children.Add(_nameEntry);

            _priceEntry = new Entry();
            _priceEntry.Keyboard = Keyboard.Text;
            _priceEntry.Placeholder = "Item Price";
            stackLayout.Children.Add(_priceEntry);

            _saveButton = new Button();
            _saveButton.Text = "Add";
            _saveButton.Clicked += saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Item>();

            var maxPrimaryKey = db.Table<Item>().OrderByDescending(x => x.Id).FirstOrDefault();

            Item item = new Item()
            {
                Id = (maxPrimaryKey == null ? 1 : maxPrimaryKey.Id + 1),
                name = _nameEntry.Text,
                price = _priceEntry.Text
            };

            db.Insert(item);
            await DisplayAlert(null, item.name + " saved", "Okay");
            await Navigation.PopAsync();
        }
    }
}