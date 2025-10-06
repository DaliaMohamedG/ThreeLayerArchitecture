using BusinessLogicLayer.DTO.EmployeeDtos;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class EmployeeController(IEmployeeServices employeeServices, IWebHostEnvironment environment, ILogger<EmployeeController> logger) : Controller
    {
        #region Index
        //baseUrl/Employee/Index => send data from controller
        public IActionResult Index()
        {
            var employees = employeeServices.GetAllEmployees();
            return View(employees);
        }
        #endregion
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDto employeeDto)
        {
            if (ModelState.IsValid)//server side validation
            {
                try
                {
                    int res = employeeServices.CreateEmployee(employeeDto);
                    if (res > 0) return RedirectToAction(nameof(Index));
                    else ModelState.AddModelError(string.Empty, "employee can't be created!");

                }
                catch (Exception ex)
                {
                    if (environment.IsDevelopment()) logger.LogError($"employee can't be created becouse {ex.Message}");
                    else
                    {
                        logger.LogError($"employee can't be created becouse {ex}");
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(employeeDto);
        }
        #endregion
        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = employeeServices.GetEmployeeById(id.Value);
            return emp is null ? NotFound() : View(emp);
        }
        #endregion
        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = employeeServices.GetEmployeeById(id.Value);
            if (emp is null) return NotFound();
            var empDto = new UpdateEmployeeDto()
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Address = emp.Address,
                IsActive = emp.IsActive,
                Email = emp.Email,
                Salary = emp.Salary,
                PhoneNumber = emp.PhoneNumber,
                HiringDate = emp.HiringDate,
                Gender = Enum.Parse<Gender>(emp.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(emp.EmployeeType)
            };
            return View(empDto);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, UpdateEmployeeDto updateEmployeeDto)
        {
            if (!id.HasValue || id != updateEmployeeDto.Id) return BadRequest();
            if (!ModelState.IsValid) return View(updateEmployeeDto);
            try
            {
                int res = employeeServices.UpdateEmployee(updateEmployeeDto);
                if (res > 0) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "employee can't be updated!");
                    return View(updateEmployeeDto);
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError($"employee can't be updated becouse {ex.Message}");
                    return View(updateEmployeeDto);
                }
                else
                {
                    logger.LogError($"employee can't be updated becouse {ex}");
                    return View("ErrorView", ex);
                }
            }
        }
        #endregion
        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool isDeleted = employeeServices.DeleteEmployee(id);
                if (isDeleted) return RedirectToAction(nameof(Index));
                else ModelState.AddModelError(string.Empty, "employee can't be deleted");
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    logger.LogError($"employee can't be deleted becouse {ex.Message}");
                    ModelState.AddModelError(string.Empty, "employee can't be deleted");
                }
                else
                {
                    logger.LogError($"employee can't be deleted becouse {ex}");
                    return View("ErrorView", ex);
                }
            }
            return RedirectToAction(nameof(Delete), new { id });
        }
        #endregion
    }
}
