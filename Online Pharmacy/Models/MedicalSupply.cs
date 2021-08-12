using System.ComponentModel.DataAnnotations;

namespace Online_Pharmacy.Models
{
    public class MedicalSupply
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Medicine's name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please, fill in how to take")]
        [Display(Name = "How to use")]
        public string Usage { get; set; }

    }
}
