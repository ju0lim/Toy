using Microsoft.AspNetCore.Mvc;

namespace JUYEONG_WEB_APPLICATION.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Login(string email, string password)
        {
            bool bSuccess = false;

            using (UserInfoDbContext context = new UserInfoDbContext())
            {
                UserInfo user = await context.GetUserInfo(email);

                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    bSuccess = true;
                }

                HttpContext.Session.SetString("User", email);
            }

            var result = new { success = bSuccess };
            return Json(result);
        }

        public async Task<JsonResult> SignUp(string email, string password, string passwordConfirm)
        {
            using (UserInfoDbContext context = new UserInfoDbContext())
            {
                UserInfo user = await context.GetUserInfo(email);

                if (user != null)
                {
                    return Json(new { success = false});
                }

                string passwordHash = BCrypt.Net.BCrypt.HashString(password);
                UserInfo userInfo = new UserInfo(email, passwordHash);
                context.UserInfo.Add(userInfo);
                await context.SaveChangesAsync();
            }

            return Json(new { success = true });
        }
    }
}
