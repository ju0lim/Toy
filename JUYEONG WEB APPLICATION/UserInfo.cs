using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JUYEONG_WEB_APPLICATION
{
    public class UserInfo
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string TimeStamp { get; set; }

        public UserInfo(string email, string password)
        {
            Email = email;
            Password = password;
            TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }

    public class UserInfoDbContext : DbContext
    {
        public DbSet<UserInfo> UserInfo { get; set; }
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

        public async Task<UserInfo> GetUserInfo(string email)
        {
            UserInfo? user = await UserInfo.FindAsync(email);
            return user;
        }
    }
}
