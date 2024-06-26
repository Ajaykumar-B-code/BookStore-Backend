﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId {  get; set; }

        public String FullName { get; set; }

        public string EmailId {  get; set; }

        public string Password {  get; set; }

        public string MobileNumber { get; set; }

        public string Role {  get; set; }
    }
}
