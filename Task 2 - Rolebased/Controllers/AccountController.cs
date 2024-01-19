using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RoleBasedAuthentication
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [Route("Account/AccessDenied")] 
        public IActionResult AccessDenied(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
    }
}

