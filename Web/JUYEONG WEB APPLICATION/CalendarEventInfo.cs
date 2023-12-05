using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JUYEONG_WEB_APPLICATION
{
    public class CalendarEventInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string TimeStamp { get; set; }

        public CalendarEventInfo(string title, string start, string end)
        {
            Title = title;
            Start = start;
            End = end;
            TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }

    public class CalendarEventInfoDbContext : DbContext
    {
        public DbSet<CalendarEventInfo> CalendarEventInfo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                string connStr = configuration.GetConnectionString("ConnStr");

                optionsBuilder.UseSqlServer(connStr);
            }
        }
    }
}
