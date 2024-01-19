using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace RoleBasedAuthentication.Controllers;

[Authorize(Roles ="User")]
public class UserController : Controller
{
     public IActionResult Index()
    {
        return View();
    }
}