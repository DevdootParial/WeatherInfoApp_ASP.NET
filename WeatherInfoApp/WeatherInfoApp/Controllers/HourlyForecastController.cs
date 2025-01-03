using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HourlyForecastController
{
    [RoutePrefix("api/hourlyforecast")]
    public class HourlyForecastController : ApiController
    {
        // Existing endpoints here...

        // POST: Create Random Hourly Forecast for Next 24 Hours
        [HttpPost]
        [Route("create-random")]
        public HttpResponseMessage CreateRandom(int locationId)
        {
            try
            {
                var success = HourlyForecastService.CreateRandomHourlyForecastsForNext24Hours(locationId);
                return success ? Request.CreateResponse(HttpStatusCode.OK, "Random 24-hour forecasts created successfully.")
                               : Request.CreateResponse(HttpStatusCode.BadRequest, "Forecast creation failed.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = HourlyForecastService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
