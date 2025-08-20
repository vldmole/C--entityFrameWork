using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyFirstMvcProject.entities;

namespace MyFirstMvcProject.context
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