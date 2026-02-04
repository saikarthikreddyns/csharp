using Microsoft.AspNetCore.Mvc;

namespace TrainHire.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Your backend is running successfully");
        }
    }
}
