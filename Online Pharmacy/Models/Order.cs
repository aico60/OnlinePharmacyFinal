using System;
using System.ComponentModel.DataAnnotations;

namespace Online_Pharmacy.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "At least one item is required")]
        [Display(Name = "Medica Supply Name")]
        public string MedicalSupplyName { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Order Cost")]
        public double OrderCost { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
    }
}
