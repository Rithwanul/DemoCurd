using DemoCurd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DemoCurd.DbContexts
{
    public class AuthorDbContext : DbContext
    {
    
        public AuthorDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Author> Author { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                                       .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                       .AddJsonFile("appsettings.json")
                                                       .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
            }

        }
    }
}
