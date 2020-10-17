using System;
using System.Collections.Generic;
using System.Text;

namespace AllegroMonitorClassLibrary
{
    public class PromotedItemModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public SellingMode sellingMode { get; set; }
        public Stock stock { get; set; }
        public Delivery delivery { get; set; }
        public List<ImagesModel> images { get; set; }
    }
}
