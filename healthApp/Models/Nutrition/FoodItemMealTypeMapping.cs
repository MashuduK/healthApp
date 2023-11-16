using System.ComponentModel.DataAnnotations;

namespace healthApp.Models.Nutrition
{
    public class FoodItemMealTypeMapping
    {
        [Key]
        public int FoodItemMealTypeMappingID { get; set; }

        [Required(ErrorMessage = "Please select a Food Item.")]
        public int FoodItemID { get; set; }
        [Required(ErrorMessage = "Please select a Meal Type.")]
        public int MealTypeID { get; set; }

        public FoodItems? FoodItem { get; set; }
        public MealType? MealType { get; set; }
    }
}
