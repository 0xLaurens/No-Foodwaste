using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Avans_NoWaste.Models;

public class IdentitySeedData
{
   private const string employeeEmail = "admin@avans.nl";
   private const string employeePassword = "AvansLover123!";

   private const string studentEmail= "student@student.avans.nl";
   private const string studentPassword = "AvansLover123!";

   public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
   {
      var employee = await userManager.FindByEmailAsync(employeeEmail);
      if (employee == null)
      {
         employee = new IdentityUser("Employee");
         await userManager.CreateAsync(employee, employeePassword);
         await userManager.AddClaimAsync(employee, new Claim("Employee", "true"));
      }

      var student = await userManager.FindByEmailAsync(studentEmail);
      if (student == null)
      {
         student = new IdentityUser("Student");
         await userManager.CreateAsync(student, studentPassword);
         await userManager.AddClaimAsync(student, new Claim("Student", "true"));
      }
   }
}