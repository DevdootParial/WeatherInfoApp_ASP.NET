using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class CurrentWeather
    {
        public int Id { get; set; }

        [Required]
        public float Temperature { get; set; }

        [Required]
        public int Humidity { get; set; }

        [Required]
        public string Condition { get; set; }
        
        public virtual Location Location { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
    }

}
