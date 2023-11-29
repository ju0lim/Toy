using Microsoft.AspNetCore.Mvc;

namespace JUYEONG_WEB_APPLICATION.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
