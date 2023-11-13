using healthApp.Models;

namespace healthApp.Models.CollectionViewModels
{
    public class AmbulanceCollection
    {
        public Ambulance Ambulance { get; set; }
        public List<AmbulanceDriver> AmbulanceDrivers { get; set; }

        public string Title
        {
            get
            {
                if (Ambulance != null && Ambulance.Id != 0)
                {
                    return "Edit Ambulance";
                }

                return "Add Ambulance";
            }
        }
    }
}
