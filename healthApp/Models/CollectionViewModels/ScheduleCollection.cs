using healthApp.Models;

namespace healthApp.Models.CollectionViewModels
{
    public class ScheduleCollection
    {
        public Schedule Schedule { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}
