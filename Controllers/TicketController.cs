using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoApi.Controllers
{
    [ApiController, Route("[controller]")]
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
