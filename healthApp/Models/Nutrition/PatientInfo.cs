using System.ComponentModel.DataAnnotations;

namespace healthApp.Models.Nutrition
{
    public class PatientInfo
    {

        [Key]
        public int PatientInfoID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Sex/Gender is required.")]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Sex must be either Male or Female.")]
        public string? Sex { get; set; }

        [Required(ErrorMessage = "Birthday is required.")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [RegularExpression(@"^\+?\d{1,4}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d{3,4}[- .]?\d{4}$", ErrorMessage = "Invalid Contact Number.")]
        public string? ContactNumber { get; set; }

        [Required(ErrorMessage = "Citizenship is required.")]
        [StringLength(50, ErrorMessage = "Citizenship cannot exceed 50 characters.")]
        public string? Citizenship { get; set; }

        [Required(ErrorMessage = "Ward is required.")]
        [StringLength(50, ErrorMessage = "Ward cannot exceed 50 characters.")]
        public string? Ward { get; set; }

        [Required(ErrorMessage = "Room is required.")]
        [StringLength(20, ErrorMessage = "Room cannot exceed 20 characters.")]
        public string? Room { get; set; }

        [Required(ErrorMessage = "Attending Doctor is required.")]
        [StringLength(100, ErrorMessage = "Attending Doctor cannot exceed 100 characters.")]
        public string? AttendingDoctor { get; set; }

        [StringLength(100, ErrorMessage = "Dietitian cannot exceed 100 characters.")]
        public string? Dietitian { get; set; }

        [Required(ErrorMessage = "Next of Kin is required.")]
        [StringLength(100, ErrorMessage = "Next of Kin cannot exceed 100 characters.")]
        public string? NextOfKin { get; set; }

        [Required(ErrorMessage = "Next of Kin Number is required.")]
        [RegularExpression(@"^\+?\d{1,4}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d{3,4}[- .]?\d{4}$", ErrorMessage = "Invalid Next of Kin Number.")]
        public string? NextOfKinNumber { get; set; }

        [Required(ErrorMessage = "Admission Date is required.")]
        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; }

        public SocialH? SocialHistory { get; set; }
        public FamilyH? FamilyHistory { get; set; }
        public SGA? SGA { get; set; }
        public Screening? Screening { get; set; }
        public MedicalH? MedicalH { get; set; }
        public Anthropometry? Anthropometry { get; set; }
        public Biochemicals? Biochemicals { get; set; }
        public DietaryInfo? DietaryInfo { get; set; }
        public FoodExchange? FoodExchange { get; set; }
        public MacroNutrients? MacroNutrients { get; set; }

    }
}
