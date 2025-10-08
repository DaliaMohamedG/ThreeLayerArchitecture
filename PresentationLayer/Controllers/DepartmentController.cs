using BusinessLogicLayer.DTO.DepartmentDtos;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class DepartmentController(DepartmentServices departmentServices, IWebHostEnvironment environment, ILogger<EmployeeController> logger) : Controller
    {
        public IActionResult Index()
        {
            //ViewData["Message"] = "hello from view data";
            //ViewBag.Message= "hello from view bag";
            ViewData["Message"] = new DpartmentDto() { Name = "test view data" };
            ViewBag.Message = new DpartmentDto() { Name = "test view bag" };
            var departments = departmentServices.GetAllDepartments();
            return View(departments);
        }
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)//server side validation
            {
                try
                {
                    int res = departmentServices.AddDepartment(departmentDto);

                    //if (res > 0) return RedirectToAction(nameof(Index));
                    //else ModelState.AddModelError(string.Empty, "department can't be created!");

                    string message;
                    if (res > 0) message = $"department {departmentDto.Name} has been created";
                    else message = $"department {departmentDto.Name} hasn't been created";
                    TempData["Message"] = message;
                    RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (environment.IsDevelopment()) logger.LogError($"department can't be created becouse {ex.Message}");
                    else
                    {
                        logger.LogError($"department can't be created becouse {ex}");
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(departmentDto);
        }
        #endregion
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
