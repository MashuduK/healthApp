using System.ComponentModel.DataAnnotations;

namespace healthApp.Models.Nutrition
{
    public class FoodItems
    {
        [Key]
        public int FoodID { get; set; }

        [Required(ErrorMessage = "FoodName is required.")]
        [StringLength(100, ErrorMessage = "FoodName should not exceed 100 characters.")]
        public string? FoodName { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [StringLength(50, ErrorMessage = "Category should not exceed 50 characters.")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "ServingSize is required.")]
        [StringLength(20, ErrorMessage = "ServingSize should not exceed 20 characters.")]
        public string? ServingSize { get; set; }

        [Required(ErrorMessage = "Calories is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Calories should be a positive number.")]
        public double Calories { get; set; }

        [Required(ErrorMessage = "Carbohydrates is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Carbohydrates should be a positive number.")]
        public double Carbohydrates { get; set; }

        [Required(ErrorMessage = "Protein is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Protein should be a positive number.")]
        public double Protein { get; set; }

        [Required(ErrorMessage = "Fat is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Fat should be a positive number.")]
        public double Fat { get; set; }

        [Required(ErrorMessage = "Fiber is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Fiber should be a positive number.")]
        public double Fiber { get; set; }

        [StringLength(100, ErrorMessage = "Vitamins should not exceed 100 characters.")]
        public string? Vitamins { get; set; }

        [StringLength(100, ErrorMessage = "Minerals should not exceed 100 characters.")]
        public string? Minerals { get; set; }
        public int PatientInfoID { get; set; }
    }
}
