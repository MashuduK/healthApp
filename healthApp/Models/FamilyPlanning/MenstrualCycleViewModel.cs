using System.ComponentModel.DataAnnotations;

namespace healthApp.Models.FamilyPlanning
{
    public class MenstrualCycleViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
