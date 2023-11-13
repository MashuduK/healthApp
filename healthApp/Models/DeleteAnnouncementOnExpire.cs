using healthApp.Areas.Identity.Data;

namespace healthApp.Models
{
    public class DeleteAnnouncementOnExpire
    {
        private static ApplicationDbContext dbContext;

        public static void DeleteAnnouncement()
        {
            var date = DateTime.Now.Date;
            dbContext.Announcements.Where(c => c.End < date)
                .ToList().ForEach(p => dbContext.Announcements.Remove(p));
            dbContext.Appointments.Where(c => c.AppointmentDate < date)
                .ToList().ForEach(p => dbContext.Appointments.Remove(p));
            dbContext.SaveChanges();
        }
    }
}
