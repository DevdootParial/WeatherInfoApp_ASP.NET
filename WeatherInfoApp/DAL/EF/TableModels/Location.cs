using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Location
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "City name is required.")]
        [StringLength(50, ErrorMessage = "City name cannot be longer than 50 characters.")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Country code is required.")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Country code must be between 2 and 5 characters.")]
        public string CountryCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<CurrentWeather> CurrentWeathers { get; set; }
        public virtual ICollection<DailyForecast> DailyForecasts { get; set; }
        public virtual ICollection<HourlyForecast> HourlyForecasts { get; set; }

        public virtual ICollection<WeatherAlert> WeatherAlerts { get; set; }

        public Location()
        {
            CurrentWeathers = new List<CurrentWeather>();
            DailyForecasts = new List<DailyForecast>();
            HourlyForecasts = new List<HourlyForecast>();
            WeatherAlerts = new List<WeatherAlert>();
        }
    }

}
