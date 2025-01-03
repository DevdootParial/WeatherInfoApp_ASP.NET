using DAL.EF.TableModels;
using DAL.Interface;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static ISearchRepo<CurrentWeather, int, bool> CurrentWeatherData()
        {
            return new CurrentWeatherRepo();
        }

        public static IRepo<Location, int, bool> LocationData()
        {
            return new LocationRepo();
        }

        public static IRepo<WeatherAlert, int, bool> WeatherAlertData()
        {
            return new WeatherAlertRepo();
        }

        public static IForecastRepo<DailyForecast, int, bool> ForecastData()
        {
            return new DailyForecastRepo();
        }

        public static IHourlyForecastRepo HourlyForecastData()
        { 
            return new HourlyForecastRepo();
        }

        public static IRepo<User, int, bool> UserData()
        {
            return new UserRepo();
        }


    }
}
