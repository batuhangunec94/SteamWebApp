using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SteamWebApp.Entities.Entity.Concrete;
using SteamWebApp.UI.Models.IdentityModel;

namespace SteamWebApp.UI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User {
                UserName = model.UserName,
                Email = model.Email,

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login","Account");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Not created before");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }
            ModelState.AddModelError("", "Username or password incorrect");
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
        [Authorize]
        public IActionResult ResetPassword()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            var userName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                ModelState.AddModelError("", "An error occurred, please try again");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _userManager.ResetPasswordAsync(user,token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Logout", "Account");
            }
            return View();
        }

        public IActionResult NewPassword()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewPassword(NewPasswordModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Bir hata oluştu lütfen tekrar deneyin");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _userManager.ResetPasswordAsync(user, token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("login", "Account");
            }
            return View();
        }
        public IActionResult Accessdenied()
        {
            return View();
        }
    }
}