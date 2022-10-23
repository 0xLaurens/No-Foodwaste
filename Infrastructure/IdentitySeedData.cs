using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure;

public static class IdentitySeedData
{
   private const string EmployeeEmail = "admin@avans.nl";
   private const string EmployeePassword = "AvansLover123!";

   private const string StudentEmail= "student@student.avans.nl";
   private const string StudentPassword = "AvansLover123!";

   public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
   {
      var employee = await userManager.FindByEmailAsync(EmployeeEmail);
      if (employee == null)
      {
         employee = new IdentityUser("Employee")
         {
            Email = EmployeeEmail 
         };
         await userManager.CreateAsync(employee, EmployeePassword);
         await userManager.AddClaimAsync(employee, new Claim("Employee", "true"));
      }

      var student = await userManager.FindByEmailAsync(StudentEmail);
      if (student == null)
      {
         student = new IdentityUser("Student")
         {
            Email = StudentEmail
         };
         await userManager.CreateAsync(student, StudentPassword);
         await userManager.AddClaimAsync(student, new Claim("Student", "true"));
      }
   }
}