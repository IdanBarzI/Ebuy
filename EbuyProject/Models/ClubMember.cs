using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    //[NotMapped]
    [Table("ClubMember")]
    public class ClubMember : Customer
    {
        public string Password { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }


    }
}
