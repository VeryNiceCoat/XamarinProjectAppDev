using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinProject.Models
{
    public class Item
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string name { get; set; }
        public string price { get; set; }


        public override string ToString()
        {
            return this.name + "(" + this.price + ")";
        }
    }
}
