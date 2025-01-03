using DAL.EF.TableModels;
using DAL.Interface;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CurrentWeatherRepo : Repo, ISearchRepo<CurrentWeather, int, bool>
    {
        public bool Create(CurrentWeather obj)
        {
            db.CurrentWeathers.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.CurrentWeathers.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<CurrentWeather> Get()
        {
            return db.CurrentWeathers.ToList();
        }

        public CurrentWeather Get(int id)
        {
            return db.CurrentWeathers.Find(id);
        }

        public bool Update(CurrentWeather obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        // Fix the issue by using int for LocationId
        public List<CurrentWeather> SearchByLocationId(int locationId)
        {
            return db.CurrentWeathers.Where(m => m.LocationId == locationId).ToList();
        }
    }
}
