using Microsoft.AspNetCore.Mvc;

namespace Cjicot.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
