using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index(string search)
        {
            var roles = string.IsNullOrEmpty(search)
                ? _roleManager.Roles.ToList()
                : _roleManager.Roles
                    .Where(r => r.Name.Contains(search))
                    .ToList();

            return View(roles);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(string roleName)
        {
            if (!string.IsNullOrEmpty(roleName))
            {
                var result = _roleManager.CreateAsync(new IdentityRole(roleName)).Result;
                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid role name");
            return View();
        }

        public IActionResult Details(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role == null) return NotFound();
            return View(role);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            return View(role);
        }

        [HttpPost]
        public IActionResult Edit(IdentityRole model)
        {
            var role = _roleManager.FindByIdAsync(model.Id).Result;
            if (role == null) return NotFound();

            role.Name = model.Name;
            var result = _roleManager.UpdateAsync(role).Result;

            if (result.Succeeded)
                return RedirectToAction("Index");

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            if (role == null) return NotFound();
            _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
    }
}
