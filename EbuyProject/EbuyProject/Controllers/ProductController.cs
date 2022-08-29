using Microsoft.AspNetCore.Mvc;
using Models;

namespace EbuyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public ProductController()
        {
            ClubMember l = new ClubMember();
            l.PurchasedProducts = new List<PurchasedProduct>();
            var sdafvc = l.PurchasedProducts;
            Transaction b = new Transaction();
        }
        [HttpGet("vsdkifghuv")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
