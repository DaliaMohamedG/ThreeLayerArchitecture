using BusinessLogicLayer.Services.Classes;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentServices departmentServices;
        public DepartmentController(DepartmentServices departmentServices)
        {
            this.departmentServices = departmentServices;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
