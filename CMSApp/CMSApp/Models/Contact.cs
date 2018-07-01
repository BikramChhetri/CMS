using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSApp.Models
{
    public enum Status
    {
        Inactive = 0,
        Active = 1
    }
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(10, ErrorMessage = "More than 20 characters are not allowed.")]
        public string FirstName { get; set; }
        [Required, MaxLength(10, ErrorMessage = "More than 20 characters are not allowed.")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Status Status { get; set; }
    }
}