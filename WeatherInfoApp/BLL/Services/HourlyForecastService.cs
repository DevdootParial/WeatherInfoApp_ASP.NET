using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class HourlyForecastService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HourlyForecast, HourlyForecastDTO>();
                cfg.CreateMap<HourlyForecastDTO, HourlyForecast>();
            });
            return new Mapper(config);
        }

        public static bool Create(HourlyForecastDTO obj)
        {
            var data = GetMapper().Map<HourlyForecast>(obj);
            return DataAccess.HourlyForecastData().Create(data);
        }

        public static List<HourlyForecastDTO> Get()
        {
            var data = DataAccess.HourlyForecastData().Get();
            return GetMapper().Map<List<HourlyForecastDTO>>(data);
        }

        public static HourlyForecastDTO Get(int id)
        {
            var data = DataAccess.HourlyForecastData().Get(id);
            return GetMapper().Map<HourlyForecastDTO>(data);
        }

        public static bool Update(HourlyForecastDTO obj)
        {
            var data = GetMapper().Map<HourlyForecast>(obj);
            return DataAccess.HourlyForecastData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccess.HourlyForecastData().Delete(id);
        }

        // Custom methods
        public static List<HourlyForecastDTO> GetByLocation(int locationId)
        {
            var data = DataAccess.HourlyForecastData().GetByLocation(locationId);
            return GetMapper().Map<List<HourlyForecastDTO>>(data);
        }

        public static List<HourlyForecastDTO> GetByDateTimeRange(DateTime start, DateTime end)
        {
            var data = DataAccess.HourlyForecastData().GetByDateTimeRange(start, end);
            return GetMapper().Map<List<HourlyForecastDTO>>(data);
        }

        // New method for creating forecasts with random start time
        public static bool CreateRandomHourlyForecastsForNext24Hours(int locationId)
        {
            List<HourlyForecastDTO> forecasts = new List<HourlyForecastDTO>();

            // Generate a random start time within the next hour
            DateTime startDateTime = DateTime.Now.AddMinutes(new Random().Next(1, 60));

            for (int i = 0; i < 24; i++) // Create 24 forecasts for the next 24 hours
            {
                HourlyForecastDTO forecast = new HourlyForecastDTO
                {
                    ForecastDateTime = startDateTime.AddHours(i), // Increment by 1 hour
                    Temperature = GetRandomTemperature(),
                    Condition = GetRandomCondition(),
                    LocationId = locationId
                };
                forecasts.Add(forecast);
            }

            return CreateBatch(forecasts); // Batch creation of 24 forecasts
        }

        // Helper method to get a random temperature
        private static float GetRandomTemperature()
        {
            return (float)Math.Round(new Random().NextDouble() * 15 + 15, 1); // Temperature range: 15.0°C to 30.0°C
        }

        // Helper method to get a random weather condition
        private static string GetRandomCondition()
        {
            string[] conditions = { "Clear", "Cloudy", "Rainy", "Partly Cloudy", "Sunny" };
            return conditions[new Random().Next(conditions.Length)];
        }

        // Batch creation method
        public static bool CreateBatch(List<HourlyForecastDTO> forecasts)
        {
            foreach (var forecast in forecasts)
            {
                var data = DataAccess.HourlyForecastData().Create(GetMapper().Map<HourlyForecast>(forecast));

                if (!data) return false;
            }
            return true;
        }
    }
}
