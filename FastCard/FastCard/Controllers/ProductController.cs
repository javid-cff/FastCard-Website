using Microsoft.AspNetCore.Mvc;

namespace FastCard.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
