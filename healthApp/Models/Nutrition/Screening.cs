using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace healthApp.Models.Nutrition
{
    public class Screening
    {
        public int ScreeningId { get; set; }

        [Range(10, 1000, ErrorMessage = "ExtremeBMI should be between 10 and 1000.")]
        public double ExtremeBMI { get; set; }

        [Range(0, 1000, ErrorMessage = "WeightLoss should be between 0 and 1000.")]
        public double WeightLoss { get; set; }

        [Range(0, 1000, ErrorMessage = "ReducedIntake should be between 0 and 1000.")]
        public double ReducedIntake { get; set; }

        [Range(0, 1000, ErrorMessage = "SevereIllness should be between 0 and 1000.")]
        public double SevereIllness { get; set; }

        [Range(0, 100, ErrorMessage = "RiskScore should be between 0 and 100.")]
        public int RiskScore { get; set; }

        // Navigation property to associated PatientInfo
        public PatientInfo? PatientInfo { get; set; }

        // Foreign key property for the relationship
        [ForeignKey("PatientInfo")]
        public int? PatientInfoID { get; set; }
    }
}
