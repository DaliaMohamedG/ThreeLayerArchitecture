using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class DepartmentController(DepartmentServices departmentServices) : Controller
    {
        public IActionResult Index()
        {
            var departments = departmentServices.GetAllDepartments();
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var department = departmentServices.GetDepartmentById(Id.Value);
            if (department is null) return NotFound(); //404
            return View(department);
        }
        public IActionResult Edit(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var department = departmentServices.GetDepartmentById(Id.Value);
            if (department is null) return NotFound(); //404
            var departmentVm = new DepartmentEditViewModel()
            {
                Code = department.Code,
                Description = department.Description,
                Name = department.Name,
                CreatedOn = (DateOnly)department.CreatedOn
            };
            return View(departmentVm);
        }
        public IActionResult Delete(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var department = departmentServices.GetDepartmentById(Id.Value);
            if (department is null) return NotFound(); //404
            return View(department);
        }

    }
}
