using Microsoft.AspNetCore.Mvc;

namespace AutenticacaoEFCookie.Controllers
{
    public class FinanceiroController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}