using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace healthApp.Models.Nutrition
{
    public class MacroNutrients
    {
        [Key] public int MacroID { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Factor value must be a non-negative value.")]
        public double Factor { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Teri LBW value must be a non-negative value.")]
        public double TeriLbw { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Teri ABW value must be a non-negative value.")]
        public double TeriAbw { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Teri CBW value must be a non-negative value.")]
        public double TeriCbw { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "kCal value must be a non-negative value.")]
        public int KCal { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Chong kg value must be a non-negative value.")]
        public double ChongKg { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "CHO value must be a non-negative value.")]
        public double Cho { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "CHON value must be a non-negative value.")]
        public double Chon { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Fat value must be a non-negative value.")]
        public double Fat { get; set; }

        [ForeignKey("PatientInfo")]
        [Required(ErrorMessage = "Patient Info ID is required.")]
        public int? PatientInfoID { get; set; }

        public PatientInfo? PatientInfo { get; set; }
    }
}
