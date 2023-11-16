using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthApp.Models.Nutrition
{
    public class MedicalH
    {
        [Key]
        public int MedicalHistoryID { get; set; }

        public string? PastIllness { get; set; }

        public string? PresentIllness { get; set; }

        public string? FoodAllergies { get; set; }

        public PatientInfo? PatientInfo { get; set; }

        [ForeignKey("PatientInfo")]
        public int PatientInfoID { get; set; }
    }
}
