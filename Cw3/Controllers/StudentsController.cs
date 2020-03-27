using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    public class StudentsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}