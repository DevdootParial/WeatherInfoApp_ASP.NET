using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CurrentWeather> CurrentWeathers { get; set; }

        public DbSet<DailyForecast> DailyForecasts { get; set; }
        public DbSet<HourlyForecast> HourlyForecasts { get; set; }

        public DbSet<WeatherAlert> WeatherAlerts { get; set; }
    }

}
