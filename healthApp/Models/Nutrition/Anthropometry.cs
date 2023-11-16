using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthApp.Models.Nutrition
{
    public class Anthropometry
    {
        [Key]
        public int anthroID { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double height { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double currentWeight { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double bmi { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double usualWeight { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double waistCircumference { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double hipCircumference { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double armCircumference { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double calfCircumference { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double tricepSkinFold { get; set; }
        [Required]
        [Range(0.0, double.MaxValue)]
        public double subscapularSkinFold { get; set; }

        public PatientInfo? PatientInfo { get; set; }

        [ForeignKey("PatientInfo")]
        public int PatientInfoID { get; set; }
    }
}
