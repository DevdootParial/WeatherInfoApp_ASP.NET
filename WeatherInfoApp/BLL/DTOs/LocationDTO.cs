using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int UserId { get; set; }
    }
}
