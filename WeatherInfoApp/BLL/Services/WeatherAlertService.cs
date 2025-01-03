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
    public class WeatherAlertService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<WeatherAlert, WeatherAlertDTO>();
                cfg.CreateMap<WeatherAlertDTO, WeatherAlert>();
            });
            return new Mapper(config);
        }
        public static bool Create(WeatherAlertDTO obj)
        {
            var data = GetMapper().Map<WeatherAlert>(obj);
            return DataAccess.WeatherAlertData().Create(data);
        }
        public static List<WeatherAlertDTO> Get()
        {
            var data = DataAccess.WeatherAlertData().Get();
            return GetMapper().Map<List<WeatherAlertDTO>>(data);
        }
        public static WeatherAlertDTO Get(int id)
        {
            var data = DataAccess.WeatherAlertData().Get(id);
            return GetMapper().Map<WeatherAlertDTO>(data);
        }
        public static bool Update(WeatherAlertDTO obj)
        {
            var data = GetMapper().Map<WeatherAlert>(obj);
            return DataAccess.WeatherAlertData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.WeatherAlertData().Delete(id);
        }

    }
}
