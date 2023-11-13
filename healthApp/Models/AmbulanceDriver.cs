using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace healthApp.Models
{
    public class AmbulanceDriver
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "CNIC")]
        public string Cnic { get; set; }

    }
}
