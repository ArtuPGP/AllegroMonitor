using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AllegroMonitor
{
    public class Item
    {
        public Item(string id, string name, string price, string available, string lowestPrice, BitmapImage bitmapImage)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.available = available;
            this.lowestPrice = lowestPrice;
            image = new Image() { Source = bitmapImage };
        }
        public string id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string available { get; set; }
        public string lowestPrice { get; set; }
        public Image image { get; set; }
    }
}
