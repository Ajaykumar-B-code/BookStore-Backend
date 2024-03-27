using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author {  get; set; }
        public double Rating { get; set; }
        public int price { get; set; }
        public int DiscountPrice {  get; set; }
        public string BookDescription { get; set; }
        public string BookImage {  get; set; }
        public int BookQuantity { get; set; }


    }
}
