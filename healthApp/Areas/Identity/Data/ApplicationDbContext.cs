
using healthApp.Models.Nutrition;
using healthApp.Areas.Identity.Data;
using healthApp.Models;
using healthApp.Models.FamilyPlanning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace healthApp.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<AmbulanceDriver> AmbulanceDrivers { get; set; }
    public DbSet<Ambulance> Ambulances { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Complaint> Complaints { get; set; }

<<<<<<< HEAD
//<<<<<<< HEAD
//    //Nutrition

//    public DbSet<PatientInfo> PatientInfos { get; set; }
//    public DbSet<SocialH> SocialHistory { get; set; }
//    public DbSet<FamilyH> FamilyHistory { get; set; }
//    public DbSet<SGA> SGA { get; set; }
//    public DbSet<Screening> Screening { get; set; }
//    public DbSet<Screening2> Screening2 { get; set; }
//    public DbSet<MacroNutrients> MacroNutrients { get; set; }
//    public DbSet<Biochemicals> Biochemicals { get; set; }
//    public DbSet<Anthropometry> Antropometry { get; set; }
//    public DbSet<FoodItems> FoodItems { get; set; }
//    public DbSet<FoodExchange> FoodExchange { get; set; }
//    public virtual DbSet<FoodExchange> DietFood { get; set; }
//    public DbSet<DietaryInfo> DietaryInfo { get; set; }
//=======
//    //FamilyPlannign
//    public DbSet<MenstrualCycle> MenstrualCycles { get; set; }
//    public DbSet<ContraceptionReminder>ContraceptionReminders { get; set; }
//    public DbSet<ContraceptionGuideRecord> ContraceptionGuideRecords { get; set; }
//    public DbSet<FertilityTrackerRecord> FertilityTrackerRecords { get; set; }

//    //public DbSet<ContraceptiveMethod> ContraceptiveMethods { get; set; }
//    public DbSet<PregnancyCalculatorRecord> PregnancyCalculatorRecords { get; set; }

//>>>>>>> cc18212ce0860394bbf7f326f712a5bff924ffbf
//=======
//    //FamilyPlannign
//    public DbSet<MenstrualCycle> MenstrualCycles { get; set; }
//    public DbSet<ContraceptionReminder>ContraceptionReminders { get; set; }
//    public DbSet<ContraceptionGuideRecord> ContraceptionGuideRecords { get; set; }
//    public DbSet<FertilityTrackerRecord> FertilityTrackerRecords { get; set; }

//    //public DbSet<ContraceptiveMethod> ContraceptiveMethods { get; set; }
//    public DbSet<PregnancyCalculatorRecord> PregnancyCalculatorRecords { get; set; }

//>>>>>>> cc18212ce0860394bbf7f326f712a5bff924ffbf

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    // You might need to customize this method based on your specific requirements
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Appointment>()
       .HasOne(a => a.Patient)
       .WithMany(p => p.Appointments)
       .HasForeignKey(a => a.PatientId)
       .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Prescription>()
            .HasOne(p => p.Patient)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.Restrict);


        // Add any additional configurations or constraints here
    }
}
