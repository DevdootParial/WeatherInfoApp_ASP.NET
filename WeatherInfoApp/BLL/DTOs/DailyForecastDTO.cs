using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DailyForecastDTO
    {
        public int Id { get; set; }
        public DateTime ForecastDate { get; set; }
        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }
        public string Condition { get; set; }
        public int LocationId { get; set; }
    }
}
