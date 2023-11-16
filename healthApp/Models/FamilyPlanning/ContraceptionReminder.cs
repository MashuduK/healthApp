namespace healthApp.Models.FamilyPlanning
{
    public class ContraceptionReminder
    {
        public int? Id { get; set; }
        public string? Method { get; set; }
        public DateTime? NextReminderDate { get; set; }
        public int? ReminderID { get; set; }
        public string? UserName { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string? ContraceptionType { get; set; }
    }
}
