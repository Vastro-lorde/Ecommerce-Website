using System;
using System.ComponentModel.DataAnnotations;

namespace SpiritEcommerce.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
