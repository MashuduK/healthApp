using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace healthApp.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Announcement")]
        public string Announcements { get; set; }
        [Required]
        [Display(Name = "Announcement For")]
        public string AnnouncementFor { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? End { get; set; }
    }
}
