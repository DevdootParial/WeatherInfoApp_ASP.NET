using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class DailyForecast
    {
        public int Id { get; set; }

        [Required]
        public DateTime ForecastDate { get; set; }

        [Required]
        public float MinTemperature { get; set; }

        [Required]
        public float MaxTemperature { get; set; }

        [Required]
        public string Condition { get; set; }

        // Navigation property for the Location
        public virtual Location Location { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
    }

}
