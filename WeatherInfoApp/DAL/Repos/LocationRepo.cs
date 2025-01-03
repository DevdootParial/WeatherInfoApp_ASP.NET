using DAL.EF.TableModels;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LocationRepo : Repo, IRepo<Location, int, bool>
    {
        public bool Create(Location obj)
        {
            db.Locations.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Locations.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Location> Get()
        {
            return db.Locations.ToList();
        }

        public Location Get(int id)
        {
            return db.Locations.Find(id);
        }

        public bool Update(Location obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

    }
}
