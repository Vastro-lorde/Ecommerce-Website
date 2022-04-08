using SpiritEcommerce.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SpiritEcommerce.ViewModel
{
    public class User
    {

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", MatchTimeoutInMilliseconds = 500)]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$", ErrorMessage = "Password must be more than 6 characters and contain at least one uppercase, lowercase, number, and special character", MatchTimeoutInMilliseconds = 500)]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
