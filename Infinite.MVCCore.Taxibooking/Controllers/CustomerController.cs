using Microsoft.AspNetCore.Mvc;

namespace Infinite.MVCCore.Taxibooking.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
