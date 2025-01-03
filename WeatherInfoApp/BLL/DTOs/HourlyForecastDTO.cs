using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class HourlyForecastDTO
    {
        public int Id { get; set; }
        public DateTime ForecastDateTime { get; set; }
        public float Temperature { get; set; }
        public string Condition { get; set; }
        public int LocationId { get; set; }
    }
}
