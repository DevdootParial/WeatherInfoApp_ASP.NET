using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LocationService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Location, LocationDTO>();
                cfg.CreateMap<LocationDTO, Location>();
            });
            return new Mapper(config);
        }
        public static bool Create(LocationDTO obj)
        {
            var data = GetMapper().Map<Location>(obj);
            return DataAccess.LocationData().Create(data);
        }
        public static List<LocationDTO> Get()
        {
            var data = DataAccess.LocationData().Get();
            return GetMapper().Map<List<LocationDTO>>(data);
        }
        public static LocationDTO Get(int id)
        {
            var data = DataAccess.LocationData().Get(id);
            return GetMapper().Map<LocationDTO>(data);
        }
        public static bool Update(LocationDTO obj)
        {
            var data = GetMapper().Map<Location>(obj);
            return DataAccess.LocationData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.LocationData().Delete(id);
        }
    }
}
