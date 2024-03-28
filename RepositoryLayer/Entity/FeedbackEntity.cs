using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class FeedbackEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int FeedBackID {  get; set; }

        [ForeignKey("BookTable")]
        public int BookId { get; set; }

        public BookEntity BookTable { get; set; }

        [ForeignKey("UserTable")]
        public int UserId {  get; set; }

        public UserEntity UserTable { get; set; }

        public float CustomerRatings {  get; set; }

        public string CustomerFeedback {  get; set; }
    }
}
