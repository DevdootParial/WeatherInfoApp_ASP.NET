using DAL.EF.TableModels;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DailyForecastRepo : Repo, IForecastRepo<DailyForecast, int, bool>
    {
        public bool Create(DailyForecast obj)
        {
            db.DailyForecasts.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var existingForecast = Get(id);
            db.DailyForecasts.Remove(existingForecast);
            return db.SaveChanges() > 0;
        }

        public List<DailyForecast> Get()
        {
            return db.DailyForecasts.ToList();
        }

        public DailyForecast Get(int id)
        {
            return db.DailyForecasts.Find(id);
        }

        public bool Update(DailyForecast obj)
        {
            var existingForecast = Get(obj.Id);
            db.Entry(existingForecast).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }




        public List<DailyForecast> GetForecastsForNext7Days(int locationId)
        {
            DateTime today = DateTime.Today;
            DateTime endDate = today.AddDays(7);

            // Fetch existing forecasts for the location for the next 7 days
            var existingForecasts = db.DailyForecasts
                .Where(df => df.LocationId == locationId && df.ForecastDate >= today && df.ForecastDate < endDate)
                .OrderBy(df => df.ForecastDate)
                .ToList();

            // Create missing forecasts if any
            var missingForecasts = new List<DailyForecast>();

            for (int i = 0; i < 7; i++)
            {
                DateTime forecastDate = today.AddDays(i);

                // Check if a forecast for this day already exists
                if (!existingForecasts.Any(f => f.ForecastDate.Date == forecastDate.Date))
                {
                    var newForecast = new DailyForecast
                    {
                        LocationId = locationId,
                        ForecastDate = forecastDate,
                        MinTemperature = GenerateRandomTemperature(),
                        MaxTemperature = GenerateRandomTemperature(),
                        Condition = GenerateRandomCondition()
                    };

                    missingForecasts.Add(newForecast);
                    db.DailyForecasts.Add(newForecast); // Add to DbSet for saving
                }
            }

            // Save newly generated forecasts to the database
            if (missingForecasts.Count > 0)
            {
                db.SaveChanges();
            }

            // Return the full list of forecasts, including generated and existing ones
            return db.DailyForecasts
                .Where(df => df.LocationId == locationId && df.ForecastDate >= today && df.ForecastDate < endDate)
                .OrderBy(df => df.ForecastDate)
                .ToList();
        }

        // Generates random temperature between -10 and 35 degrees Celsius
        private float GenerateRandomTemperature()
        {
            Random rand = new Random();
            return (float)(rand.NextDouble() * (35 - (-10)) + (-10));  // Generates temperatures between -10 and 35°C
        }

        // Generates random weather conditions
        private string GenerateRandomCondition()
        {
            string[] conditions = { "Sunny", "Cloudy", "Rainy", "Snowy", "Stormy", "Windy" };
            Random rand = new Random();
            return conditions[rand.Next(conditions.Length)];
        }


    }
}
