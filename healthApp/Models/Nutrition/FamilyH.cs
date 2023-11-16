using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthApp.Models.Nutrition
{
    public class FamilyH
    {
        [Key] public int FamilyHistoryID { get; set; }

        [Required(ErrorMessage = "Please select an option for Cardiovascular Disease.")]
        public bool? CardiovascularDisease { get; set; }

        [Required(ErrorMessage = "Please select an option for Neuromuscular Disease.")]
        public bool? NeuromuscularDisease { get; set; }

        [Required(ErrorMessage = "Please select an option for Gastrointestinal Disease.")]
        public bool? GastrointestinalDisease { get; set; }

        [Required(ErrorMessage = "Please select an option for Kidney Disease.")]
        public bool? KidneyDisease { get; set; }

        [Required(ErrorMessage = "Please select an option for Endocrine Disease.")]
        public bool? EndocrineDisease { get; set; }

        [Required(ErrorMessage = "Please select an option for Diabetes Mellitus Type 1.")]
        public bool? DiabetesMellitusType1 { get; set; }

        [Required(ErrorMessage = "Please select an option for Diabetes Mellitus Type 2.")]
        public bool? DiabetesMellitusType2 { get; set; }

        [Required(ErrorMessage = "Please select an option for Pulmonary Disease.")]
        public bool? PulmonaryDisease { get; set; }

        [Required(ErrorMessage = "Please select an option for Cancer.")]
        public bool? Cancer { get; set; }

        [ForeignKey("PatientInfo")]
        public int PatientInfoID { get; set; }
        public PatientInfo? PatientInfo { get; set; }
    }
}
