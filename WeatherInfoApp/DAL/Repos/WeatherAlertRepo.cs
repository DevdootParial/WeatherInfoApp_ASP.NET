using DAL.EF.TableModels;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class WeatherAlertRepo : Repo, IRepo<WeatherAlert, int, bool>
    {
        public bool Create(WeatherAlert obj)
        {
            db.WeatherAlerts.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.WeatherAlerts.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<WeatherAlert> Get()
        {
            return db.WeatherAlerts.ToList();
        }

        public WeatherAlert Get(int id)
        {
            return db.WeatherAlerts.Find(id);
        }

        public bool Update(WeatherAlert obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

    }
}
