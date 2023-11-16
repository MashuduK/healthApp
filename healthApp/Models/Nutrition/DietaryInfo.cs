using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace healthApp.Models.Nutrition
{
    public class DietaryInfo
    {
        [Key]
        public int DietaryInfoID { get; set; }

        [Display(Name = "Breakfast Food")]
        public string BreakfastFood { get; set; }

        [Display(Name = "Breakfast Method")]
        public string BreakfastMethod { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Breakfast amount must be a non-negative value.")]
        public double BreakfastAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Breakfast total calories must be a non-negative value.")]
        public double BreakfastTotalCalories { get; set; }

        [Display(Name = "AM Snack Food")]
        public string AMSnackFood { get; set; }

        [Display(Name = "AM Snack Method")]
        public string AMSnackMethod { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "AM snack amount must be a non-negative value.")]
        public double AMSnackAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "AM snack total calories must be a non-negative value.")]
        public double AMSnacktotalclories { get; set; }

        [Display(Name = "Lunch Food")]
        public string LunchFood { get; set; }

        [Display(Name = "Lunch Method")]
        public string LunchMethod { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Lunch amount must be a non-negative value.")]
        public double LunchAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Lunch total calories must be a non-negative value.")]
        public double LunchTotalCalories { get; set; }

        [Display(Name = "PM Snack Food")]
        public string PMSnackFood { get; set; }

        [Display(Name = "PM Snack Method")]
        public string PMSnackMethod { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "PM snack amount must be a non-negative value.")]
        public double PMSnackAmout { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "PM snack total calories must be a non-negative value.")]
        public double PMSnackTotalCalories { get; set; }

        [Display(Name = "Dinner Food")]
        public string DinnerFood { get; set; }

        [Display(Name = "Dinner Method")]
        public string DinnerMethod { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Dinner amount must be a non-negative value.")]
        public double DinnerAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Dinner total calories must be a non-negative value.")]
        public double DinnerTotalCalories { get; set; }

        [ForeignKey("PatientInfo")]
        [Required(ErrorMessage = "Patient Info ID is required.")]
        public int? PatientInfoID { get; set; }

        public PatientInfo? PatientInfo { get; set; }
    }
}
