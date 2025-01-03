using DAL.EF.TableModels;
using DAL.Interface;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IHourlyForecastRepo : IRepo<HourlyForecast, int, bool>
    {
        List<HourlyForecast> GetByLocation(int locationId);  // Get forecasts by location
        List<HourlyForecast> GetByDateTimeRange(DateTime start, DateTime end);  // Get forecasts in a date range
    }
}