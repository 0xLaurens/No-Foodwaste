using Avans_NoWaste.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Avans_NoWaste.Controllers;

public class AccountController: Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
    {
        _userManager = userMgr;
        _signInManager = signInMgr;

        IdentitySeedData.EnsurePopulated(userMgr).Wait();
    }
   
    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel
        {
            ReturnUrl = returnUrl  
        });
    }
   
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken] 
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            var user =
                await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user != null)
            {
                await _signInManager.SignOutAsync();
                if ((await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false)).Succeeded)
                {
                    return Redirect(loginViewModel?.ReturnUrl ?? "/Home/Index");
                }
                
            }
        }
        ModelState.AddModelError("", "Invalid name or password");
        return View(loginViewModel);
    }
}