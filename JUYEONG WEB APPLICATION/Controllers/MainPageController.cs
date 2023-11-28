using Microsoft.AspNetCore.Mvc;

namespace JUYEONG_WEB_APPLICATION.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
