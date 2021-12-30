using Microsoft.AspNetCore.Mvc;

namespace Cjicot.Web.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult dashboard()
        {
            return View();
        }

        public IActionResult UploadManuscript()
        {
            return View();
        }
    }
}
