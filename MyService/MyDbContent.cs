using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using MyCommon;
using Microsoft.Extensions.Configuration;
using System.IO;
using MyService.Config;

namespace MyService
{
    public class MyDbContent:DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configRoot = builder.Build();
            var dbstring = configRoot.GetSection("db").GetSection("ConnectionString").Value;

            optionsBuilder.UseMySQL(dbstring);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var asmServices = Assembly.Load(new AssemblyName("MyService"));
            modelBuilder.ApplyConfigurationsFromAssembly(asmServices);
        }
    }
}
