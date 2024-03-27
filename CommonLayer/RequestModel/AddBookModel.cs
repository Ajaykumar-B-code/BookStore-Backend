using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class AddBookModel
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public int price { get; set; }
        public int DiscountPrice { get; set; }
        public string BookDescription { get; set; }
        public int BookQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
