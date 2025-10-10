using DataAccessLayer.Models.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Helper;
using PresentationLayer.Models.AccountViewModel;

namespace PresentationLayer.Controllers
{
    public class AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : Controller
    {
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);
            var user = new ApplicationUser()
            {
                FristName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email
            };
            var res = userManager.CreateAsync(user, registerViewModel.Password).Result;
            if (res.Succeeded) return RedirectToAction("Login");
            else
            {
                foreach (var error in res.Errors) ModelState.AddModelError(string.Empty, error.Description);
                return View(registerViewModel);
            }
        }
        #endregion
        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await userManager.FindByEmailAsync(loginViewModel.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid Email or Password.");
                return View(loginViewModel);
            }

            var result = await signInManager.PasswordSignInAsync(
                user,
                loginViewModel.Password,
                loginViewModel.RememberMe,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid Email or Password.");
            return View(loginViewModel);
        }

        #endregion
        #region SignOut
        [HttpGet]
        public IActionResult SignOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        #endregion
        #region Forget Password

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> SendResetPasswordLink(ForgetPasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return View("ForgetPassword", model);

        //    var user = await userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //    {
        //        TempData["Message"] = "If this email is registered, a reset link has been sent.";
        //        return RedirectToAction("Login");
        //    }
        //    var token = await userManager.GeneratePasswordResetTokenAsync(user);
        //    var resetLink = Url.Action("ResetPassword", "Account",
        //        new { email = model.Email, token = token },
        //        protocol: HttpContext.Request.Scheme);

        //    Console.WriteLine($"Reset Password Link: {resetLink}");

        //    TempData["Message"] = "If this email is registered, a reset link has been sent.";
        //    return RedirectToAction("Login");
        //}

        #endregion
        #region send reset password link
        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByEmailAsync(model.Email).Result;
                if (user is not null)
                {
                    //send email
                    var token = userManager.GeneratePasswordResetTokenAsync(user).Result;
                    var resetPasswordLink = Url.Action("ResetPassword", "Account",
                    new { email = model.Email, token = token }, Request.Scheme);
                    var email = new Email()
                    {
                        To = model.Email,
                        Subject = "reset password",
                        Body = resetPasswordLink //link
                    };
                    //call send email => email
                    EmailSetting.SendEmail(email);
                    return RedirectToAction("CheckYourInbox");
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid Operation");
            return View(nameof(ForgetPassword), model);
        }
        #endregion
        #region CheckYourInbox
        [HttpGet]
        public IActionResult CheckYourInbox()
        {
            return View();
        }
        #endregion
        #region Reset Password
        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            if (email == null || token == null)
                return RedirectToAction("Login");

            var model = new ResetPasswordViewModel
            {
                Email = email,
                Token = token
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = userManager.FindByEmailAsync(model.Email).Result;
            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email address");
                return View(model);
            }

            var result = userManager.ResetPasswordAsync(user, model.Token, model.Password).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }
        #endregion

    }
}
