using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace healthApp.Models.Nutrition
{
    public class Screening2
    {
        [Key]
        public int ScreeningId { get; set; }


        [Display(Name = "Extreme BMI")]
        [Range(10, 100, ErrorMessage = "ExtremeBMI should be between 10 and 100.")]
        public double ExtremeBMI { get; set; } /*= random.NextDouble() * (100 - 10) + 10;
*/
        [Display(Name = "Weight Loss")]
        [Range(0, 100, ErrorMessage = "WeightLoss should be between 0 and 100.")]
        public double WeightLoss { get; set; } /* random.NextDouble() * 100;*/

        [Display(Name = "Reduced Intake")]
        [Range(0, 100, ErrorMessage = "ReducedIntake should be between 0 and 100.")]
        public double ReducedIntake { get; set; } /*= random.NextDouble() * 100;*/

        [Display(Name = "Severe Illness")]
        [Range(0, 100, ErrorMessage = "SevereIllness should be between 0 and 100.")]
        public double SevereIllness { get; set; }/* = random.NextDouble() * 100;
*/
        [Display(Name = "Risk Score")]
        [Range(0, 10, ErrorMessage = "RiskScore should be between 0 and 10.")]
        public int RiskScore { get; set; } /*= random.Next(11);*/

        // Navigation property to associated PatientInfo
        public PatientInfo? PatientInfo { get; set; }

        // Foreign key property for the relationship
        [ForeignKey("PatientInfo")]
        public int? PatientInfoID { get; set; }
    }
}
