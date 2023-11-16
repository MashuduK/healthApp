using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace healthApp.Models.FamilyPlanning
{
    public class PregnancyCalculatorRecord
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Last Menstrual Period (LMP)")]
        [DataType(DataType.Date)]
        public DateTime LMP { get; set; }

        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Pregnancy Week")]
        public int PregnancyWeek { get; set; }
    }
}
