using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace healthApp.Models.Nutrition
{
    public class SGA
    {
        [Key]
        public int SgaID { get; set; }

        [Required(ErrorMessage = "Weight loss is required.")]
        public double WeightLoss { get; set; }

        [Range(0, 4, ErrorMessage = "Food intake must be between 0 and 4.")]
        public int FoodIntake { get; set; }

        public string? GastrointestinalSymptom { get; set; }

        [Range(0, 4, ErrorMessage = "Functional capacity must be between 0 and 4.")]
        public int FunctionalCapacity { get; set; }

        public string? NutritionalRequirementDisease { get; set; }

        public string? PhysicalExam { get; set; }

        [Required(ErrorMessage = "Please select an option for Edema presence.")]
        public bool EdemaPresence { get; set; }

        [Range(0, 5)]
        public double AlbuminSGA { get; set; }

        [Range(0, 5)]
        public double BMI { get; set; }

        [Range(0, 5)]
        public int TIC { get; set; }

        [Range(0, 5)]
        public int TotalScore { get; set; }

        public PatientInfo? PatientInfo { get; set; }

        [ForeignKey("PatientInfo")]
        public int PatientInfoID { get; set; }
    }
}
