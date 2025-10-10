using DataAccessLayer.Models.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class UserManagerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index(string search)
        {
            var users = string.IsNullOrEmpty(search)
                ? _userManager.Users.ToList()
                : _userManager.Users
                    .Where(u => u.UserName.Contains(search) || u.Email.Contains(search))
                    .ToList();

            return View(users);
        }

        public IActionResult Details(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationUser model)
        {
            var user = _userManager.FindByIdAsync(model.Id).Result;
            if (user == null) return NotFound();

            user.FristName = model.FristName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = _userManager.UpdateAsync(user).Result;
            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null) return NotFound();

            var result = _userManager.DeleteAsync(user).Result;
            return RedirectToAction("Index");
        }
    }
}
