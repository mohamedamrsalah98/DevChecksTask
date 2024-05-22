using Microsoft.AspNetCore.Mvc;
using EmployeeMvc.Models;
using EmployeeMvc.Services;

namespace EmployeeMvc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddEmployeeAsync(employee);

                TempData["SuccessMessage"] = "Employee added successfully!";

                return RedirectToAction(nameof(Create));
            }

            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }




    }
}
