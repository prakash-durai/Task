using EfCoreInheritance;
using Microsoft.AspNetCore.Mvc;
public class EmployeesController : Controller
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeesController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IActionResult Index()
    {
        var employees = _employeeRepository.GetAllEmployees();
        return View(employees);
    }
}
