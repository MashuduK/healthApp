using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace healthApp.Models.FamilyPlanning
{
    public class ContraceptionGuideRecord
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Contraception Type")]
        public string ContraceptionType { get; set; }

        [Display(Name = "Effectiveness")]
        public string Effectiveness { get; set; }

        [Display(Name = "Side Effects")]
        public string SideEffects { get; set; }

        [Display(Name = "Cost")]
        public string Cost { get; set; }
    }
}
