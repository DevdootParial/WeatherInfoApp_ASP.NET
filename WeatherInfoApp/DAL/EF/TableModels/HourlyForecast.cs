using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class HourlyForecast
    {
        public int Id { get; set; }
        public DateTime ForecastDateTime { get; set; }
        public float Temperature { get; set; }
        public string Condition { get; set; }

        // Navigation property for the Location
        public virtual Location Location { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
    }

}
