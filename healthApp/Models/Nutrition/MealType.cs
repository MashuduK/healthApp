using System.ComponentModel.DataAnnotations;

namespace healthApp.Models.Nutrition
{
    public class MealType
    {
        [Key]
        public int MealTypeID { get; set; }

        [Required(ErrorMessage = "MealTypeName is required.")]
        [StringLength(50, ErrorMessage = "MealTypeName should not exceed 50 characters.")]
        public string? MealTypeName {get; set;}
    }
}
