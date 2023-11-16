namespace healthApp.Models.FamilyPlanning
{
    public class MenstrualCycle
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Foreign key to link with the user
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
