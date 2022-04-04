using SpiritEcommerce.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpiritEcommerce.Models
{
    public class User
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
