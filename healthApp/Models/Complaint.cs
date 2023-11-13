using System.ComponentModel.DataAnnotations;

namespace healthApp.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        [Required]
        public string Complain { get; set; }
        public string Reply { get; set; }
        public DateTime? ComplainDate { get; set; }
    }
}
