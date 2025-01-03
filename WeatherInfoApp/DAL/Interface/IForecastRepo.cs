using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IForecastRepo<CLASS, ID, RET> : IRepo<CLASS, ID, RET>
    {
        // Method for getting forecasts for the next 7 days
        List<CLASS> GetForecastsForNext7Days(int locationId);
    }
}
