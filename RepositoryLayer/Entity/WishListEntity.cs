using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entity
{
    public class WishListEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListId { get; set; }

        [ForeignKey("UserTable")]
        public int UserId { get; set; }
        [JsonIgnore]
        public UserEntity UserTable {  get; set; }

        [ForeignKey("BookTable")]
        public int BookId {  get; set; }
        [JsonIgnore]
        public BookEntity BookTable { get; set;}

    }
}
