using Online_Pharmacy.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Online_Pharmacy.Views.Users.ViewModel
{
    public class User : SiteUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Father  name")]
        [Required]
        public string FatherName { get; set; }
        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Starting date")]
        public DateTime StartingDate { get; set; }
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Phone number")]
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Telephone number number must consist of 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
