using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetcore_angular_sample.Data;

namespace dotnetcore_angular_sample.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private  AppDBContext  _context;

        public SampleDataController(AppDBContext context)
        {
            _context = context;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();

            var weatherList = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            _context.WeatherForecasts.AddRange(weatherList);
            _context.SaveChanges();

            return weatherList;
        }

       
    }
}
