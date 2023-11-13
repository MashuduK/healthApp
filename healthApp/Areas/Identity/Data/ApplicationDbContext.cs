﻿
using healthApp.Areas.Identity.Data;
using healthApp.Models;
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
