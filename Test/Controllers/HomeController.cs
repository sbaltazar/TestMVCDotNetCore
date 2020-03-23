using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }
    
        public ViewResult Details(int? id)
        {
            var homeDetailsViewModel = new HomeDetailsViewModel
            {
                Employee = _employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }
    }
}
