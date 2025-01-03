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
    public class DailyForecastService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DailyForecast, DailyForecastDTO>();
                cfg.CreateMap<DailyForecastDTO, DailyForecast>();
            });
            return new Mapper(config);
        }

        public static bool Create(DailyForecastDTO obj)
        {
            var data = GetMapper().Map<DailyForecast>(obj);
            return DataAccess.ForecastData().Create(data);
        }

        public static List<DailyForecastDTO> Get()
        {
            var data = DataAccess.ForecastData().Get();
            return GetMapper().Map<List<DailyForecastDTO>>(data);
        }

        public static DailyForecastDTO Get(int id)
        {
            var data = DataAccess.ForecastData().Get(id);
            return GetMapper().Map<DailyForecastDTO>(data);
        }

        public static bool Update(DailyForecastDTO obj)
        {
            var data = GetMapper().Map<DailyForecast>(obj);
            return DataAccess.ForecastData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccess.ForecastData().Delete(id);
        }

        public static List<DailyForecastDTO> GetForecastsForNext7Days(int locationId)
        {
            var data = DataAccess.ForecastData().GetForecastsForNext7Days(locationId);
            return GetMapper().Map<List<DailyForecastDTO>>(data);
        }
    }
}
