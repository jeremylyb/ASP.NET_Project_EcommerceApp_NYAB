using Microsoft.AspNetCore.Mvc;

namespace NotYourAverageBicepShoppingApp.ProductRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
