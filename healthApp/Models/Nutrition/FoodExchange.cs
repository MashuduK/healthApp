using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace healthApp.Models.Nutrition
{
    public class FoodExchange
    {

        [Key] public int FoodExchangeID { get; set; }

        [Display(Name = "Diet Discription")]
        public string? DietDiscription { get; set; }


        [Required]
        public string? Breakfast { get; set; }
        [Required]
        public string? AMSnack { get; set; }
        [Required]
        public string? Lunch { get; set; }
        [Required]
        public string? PMSnack { get; set; }

        [Display(Name = "Dinner / Supper")]
        public string? DinnerSupper { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Total items must be a non-negative value.")]
        public int TotalItems { get; set; }

        [ForeignKey("PatientInfo")]
        [Required(ErrorMessage = "Patient Info ID is required.")]
        public int PatientInfoID { get; set; }

        public PatientInfo? PatientInfo { get; set; }
    }
}
