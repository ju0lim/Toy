﻿using Microsoft.AspNetCore.Mvc;
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
                title = e.Title,
                start = e.Start,
                end = e.End
            }));
        }

        public async Task<JsonResult> AddEvent(string title, string start, string end)
        {
            using (CalendarEventInfoDbContext context = new CalendarEventInfoDbContext())
            {
                CalendarEventInfo? info = await context.CalendarEventInfo.FindAsync(title, start, end);

                if (info != null)
                {
                    return Json(new { success = false });
                }

                context.CalendarEventInfo.Add(new CalendarEventInfo(title, start, end));
                await context.SaveChangesAsync();
            }
            return Json(new { success = true });
        }

        public async Task<JsonResult> RemoveEvent(string title, string start, string end)
        {
            using (CalendarEventInfoDbContext context = new CalendarEventInfoDbContext())
            {
                CalendarEventInfo? info = await context.CalendarEventInfo.FindAsync(title, start, end);

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
                CalendarEventInfo? info = await context.CalendarEventInfo.FindAsync(data.BeforeTitle, data.BeforeStart, data.BeforeEnd);

                try
                {
                    if (info != null)
                    {
                        info.Title = data.ModifyTitle;
                        info.Start = data.ModifyStart;
                        info.End = data.ModifyEnd;
                        info.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        await context.SaveChangesAsync();
                        return Json(new { success = true });
                    }
                }
                catch (Exception e)
                {
                    return Json(new { success = true, message = e.Message });
                }
                
            }
            return Json(new { success = false });
        }
    }

    public class EditData
    {
        public string? BeforeTitle { get; set; }
        public string? BeforeStart { get; set; }
        public string? BeforeEnd { get; set; }
        public string? ModifyTitle { get; set; }
        public string? ModifyStart { get; set; }
        public string? ModifyEnd { get; set; }
    }
}