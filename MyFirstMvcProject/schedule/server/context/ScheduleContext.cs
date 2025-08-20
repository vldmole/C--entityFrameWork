using Microsoft.EntityFrameworkCore;
using schedule.server.entity;

namespace schedule.server.context
{
    public class ScheduleContext(IConfiguration configuration) : DbContext
    {
        private readonly IConfiguration _appSettings = configuration;

        public DbSet<Contact> Contacts { get; set; }
    
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = _appSettings.GetConnectionString("MySql");

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception($"Database connection string could not be null {connectionString}");

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );
        }
    }
}