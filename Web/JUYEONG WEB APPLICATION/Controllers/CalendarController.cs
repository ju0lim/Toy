using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JUYEONG_WEB_APPLICATION.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> InitEvents()
        {
            List<CalendarEventInfo> events;
            using (CalendarEventInfoDbContext context = new CalendarEventInfoDbContext())
            {
                events = await context.CalendarEventInfo.ToListAsync();
            }
            
            return Ok(events.Select(e => new
            {
                id = e.EventID,
                title = e.Title,
                start = e.Start,
                end = e.End
            }));
        }

        public async Task<JsonResult> AddEvent(string title, string start, string end)
        {
            using (CalendarEventInfoDbContext context = new CalendarEventInfoDbContext())
            {
                context.CalendarEventInfo.Add(new CalendarEventInfo(title, start, end));
                await context.SaveChangesAsync();
            }
            return Json(new { success = true });
        }

        public async Task<JsonResult> RemoveEvent(int id)
        {
            using (CalendarEventInfoDbContext context = new CalendarEventInfoDbContext())
            {
                CalendarEventInfo? info = await context.CalendarEventInfo.FindAsync(id);

                if (info != null)
                {
                    context.CalendarEventInfo.Remove(info);
                    await context.SaveChangesAsync();
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }

        public async Task<JsonResult> ModifyEvent(EditData data)
        {
            using (CalendarEventInfoDbContext context = new CalendarEventInfoDbContext())
            {
                CalendarEventInfo? beforeInfo = await context.CalendarEventInfo.FindAsync(data.ID);

                try
                {
                    if (beforeInfo != null)
                    {
                        beforeInfo.Title = data.ModifyTitle;
                        beforeInfo.Start = data.ModifyStart;
                        beforeInfo.End = data.ModifyEnd;
                        beforeInfo.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        await context.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                }
                catch (Exception e)
                {
                    return Json(new { success = false, message = e.Message });
                }
                
            }
            return Json(new { success = false });
        }
    }

    public class EditData
    {
        public int ID { get; set; }
        public string? ModifyTitle { get; set; }
        public string? ModifyStart { get; set; }
        public string? ModifyEnd { get; set; }
    }
}
