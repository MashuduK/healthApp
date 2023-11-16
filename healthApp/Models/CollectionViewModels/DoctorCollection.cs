
using healthApp.Areas.Identity.Pages.Account;

namespace healthApp.Models.CollectionViewModels
{
    public class DoctorCollection
    {
        public RegisterModel.InputModel ApplicationUser { get; set; }
        public Doctor Doctor { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
