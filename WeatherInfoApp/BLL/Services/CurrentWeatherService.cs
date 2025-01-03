using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CurrentWeatherService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CurrentWeather, CurrentWeatherDTO>();
                cfg.CreateMap<CurrentWeatherDTO, CurrentWeather>();
            });
            return new Mapper(config);
        }

        public static bool Create(CurrentWeatherDTO obj)
        {
            var data = GetMapper().Map<CurrentWeather>(obj);
            return DataAccess.CurrentWeatherData().Create(data);
        }

        public static List<CurrentWeatherDTO> Get()
        {
            var data = DataAccess.CurrentWeatherData().Get();
            return GetMapper().Map<List<CurrentWeatherDTO>>(data);
        }

        public static CurrentWeatherDTO Get(int id)
        {
            var data = DataAccess.CurrentWeatherData().Get(id);
            return GetMapper().Map<CurrentWeatherDTO>(data);
        }

        public static bool Update(CurrentWeatherDTO obj)
        {
            var data = GetMapper().Map<CurrentWeather>(obj);
            return DataAccess.CurrentWeatherData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccess.CurrentWeatherData().Delete(id);
        }

        // Fix: ensure LocationId is int
        public static List<CurrentWeatherDTO> SearchByLocationId(int locationId)
        {
            var data = DataAccess.CurrentWeatherData().SearchByLocationId(locationId);
            return GetMapper().Map<List<CurrentWeatherDTO>>(data);
        }
    }
}
