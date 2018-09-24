using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore_angular_sample.Data 
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) {
            //Database.EnsureCreated();

            Database.Migrate();
        }


        public DbSet<WeatherForecast> WeatherForecasts {get;set;}
    }
}
