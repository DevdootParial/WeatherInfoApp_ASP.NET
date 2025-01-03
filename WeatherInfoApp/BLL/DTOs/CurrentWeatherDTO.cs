using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CurrentWeatherDTO
    {
        public int Id { get; set; }
        public float Temperature { get; set; }
        public int Humidity { get; set; }
        public string Condition { get; set; }
        public int LocationId { get; set; }
    }
}
