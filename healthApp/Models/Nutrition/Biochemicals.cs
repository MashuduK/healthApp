using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace healthApp.Models.Nutrition
{
    public class Biochemicals
    {
        [Key]
        public int BioID { get; set; }

        [Required(ErrorMessage = "Smoking frequency is required.")]
        public string? SmokingFrequency { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Uric acid must be a non-negative value.")]
        public double uricAcid { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Cholesterol must be a non-negative value.")]
        public double cholesterol { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total protein must be a non-negative value.")]
        public double totalProtein { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Albumin must be a non-negative value.")]
        public double albumin { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Globulin must be a non-negative value.")]
        public double globulin { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Amylase must be a non-negative value.")]
        public double amylase { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Lipase must be a non-negative value.")]
        public double lipase { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Hemoglobin must be a non-negative value.")]
        public double hemoglobin { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Sodium must be a non-negative value.")]
        public double sodium { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Potassium must be a non-negative value.")]
        public double potassium { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Calcium must be a non-negative value.")]
        public double calcium { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Magnesium must be a non-negative value.")]
        public double magnesium { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Ammonia must be a non-negative value.")]
        public double ammonia { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Bleeding time must be a non-negative value.")]
        public double bleedingTime { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Clotting time must be a non-negative value.")]
        public double clottingTime { get; set; }

        [ForeignKey("PatientInfo")]
        [Required(ErrorMessage = "Patient Info ID is required.")]
        public int PatientInfoID { get; set; }

        public PatientInfo? PatientInfo { get; set; }
    }
}
