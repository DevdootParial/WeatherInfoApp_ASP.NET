using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class WeatherAlertDTO
    {
        public int Id { get; set; }
        public string AlertType { get; set; }
        public string AlertMessage { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public int LocationId { get; set; }
    }
}
