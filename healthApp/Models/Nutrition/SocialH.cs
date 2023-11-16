using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace healthApp.Models.Nutrition
{
    public class SocialH
    {
        [Key]
        public int SocialHistoryID { get; set; }

        [Range(0, 5, ErrorMessage = "Smoking frequency should be between 0 and 5.")]
        public int SmokingFrequency { get; set; }

        [Required(ErrorMessage = "Please select an alcohol type.")]
        public string? AlcoholType { get; set; }

        [Range(0, 5, ErrorMessage = "Alcohol frequency should be between 0 and 5.")]
        public int AlcoholFrequency { get; set; }

        [Range(0, 5, ErrorMessage = "Alcohol quantity should be between 0 and 5.")]
        public int AlcoholQuantity { get; set; }

        [Range(0, 5, ErrorMessage = "Physical activity level should be between 0 and 5.")]
        public int PhysActivity { get; set; }
        public PatientInfo? PatientInfo { get; set; }

        [ForeignKey("PatientInfo")]
        public int? PatientInfoID { get; set; }
    }
}
