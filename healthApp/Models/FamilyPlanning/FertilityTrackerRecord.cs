using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace healthApp.Models.FamilyPlanning
{
    public class FertilityTrackerRecord
    {
        public int Id { get; set; }

        [Display(Name = "Cycle Length")]
        [Required]
        public int CycleLength { get; set; }

        [Display(Name = "Ovulation Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime OvulationDate { get; set; }

        [Display(Name = "Fertility Window Start")]
        [DataType(DataType.Date)]
        public DateTime FertilityWindowStart { get; set; }

        [Display(Name = "Fertility Window End")]
        [DataType(DataType.Date)]
        public DateTime FertilityWindowEnd { get; set; }
    }
}
