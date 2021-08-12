using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Pharmacy.Models
{
    public class SiteUser : IdentityUser
    {
        //public int Id { get; set; }

        [Display(Name = "First name")]
        [Required]
        [Column]
        public string FirstName { get; set; }
        [Display(Name = "Father  name")]
        [Required]
        [Column]
        public string FatherName { get; set; }
        [Display(Name = "Last name")]
        [Required]
        [Column]
        public string LastName { get; set; }

        [Display(Name = "Starting date")]
        [Column]
        public DateTime StartingDate { get; set; }
        [Display(Name = "Release date")]
        [Column]
        public DateTime ReleaseDate { get; set; }
    }
}
