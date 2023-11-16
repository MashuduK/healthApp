using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using healthApp.Models.FamilyPlanning;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace healthApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }
    public string? UserRole { get; set; }
    public DateTime RegisteredDate { get; set; }
    public ICollection<MenstrualCycle> MenstrualCycles { get; set; }

    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    {
        var userIdentity = await manager.CreateAsync(this);

        if (userIdentity.Succeeded)
        {
            // Modify this part based on your requirements
            var claimsIdentity = new ClaimsIdentity("ApplicationCookie");
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, Id));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, Id));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, Email));

            // Add any custom claims here

            return claimsIdentity;
        }

        // Handle the case when creating the user identity fails
        return null;
    }
}



