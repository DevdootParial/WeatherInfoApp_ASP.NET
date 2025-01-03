using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class HourlyForecastRepo : Repo, IHourlyForecastRepo
    {
        public bool Create(HourlyForecast obj)
        {
            db.HourlyForecasts.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<HourlyForecast> Get()
        {
            return db.HourlyForecasts.ToList();
        }

        public HourlyForecast Get(int id)
        {
            return db.HourlyForecasts.Find(id);
        }

        public bool Update(HourlyForecast obj)
        {
            var existing = Get(obj.Id);
            if (existing != null)
            {
                db.Entry(existing).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = Get(id);
            if (existing != null)
            {
                db.HourlyForecasts.Remove(existing);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        // Custom methods
        public List<HourlyForecast> GetByLocation(int locationId)
        {
            return db.HourlyForecasts.Where(f => f.LocationId == locationId).ToList();
        }

        public List<HourlyForecast> GetByDateTimeRange(DateTime start, DateTime end)
        {
            return db.HourlyForecasts.Where(f => f.ForecastDateTime >= start && f.ForecastDateTime <= end).ToList();
        }
    }
}