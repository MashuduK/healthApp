namespace healthApp.Models.FamilyPlanning
{
    public class ContraceptionReminder
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public DateTime NextReminderDate { get; set; }
    }
}
