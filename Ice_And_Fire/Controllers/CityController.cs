using IAF.Data;
using IAF.Model.City.m;
using IAF.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Ice_And_Fire.Controllers
{
    
    public class CityController : ApiController
    {
        private CityService CreateCityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cityService = new CityService(userId);
            return cityService;
        }
        public IHttpActionResult Get()
        {
            CityService cityService = CreateCityService();
            var cities = cityService.GetCities();
            return Ok(cities);
        }
        public IHttpActionResult Post(CityCreate city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateCityService();
            if (!service.CreateCity(city))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            CityService cityService = CreateCityService();
            var city = cityService.GetCityById(id); return Ok(city);
        }
        public IHttpActionResult Put(CityEdit city)  //update city
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateCityService();
            if (!service.UpdateCity(city))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult DeleteCity(int id)
        {
            var service = CreateCityService();
            if (!service.DeleteCity(id))
                return InternalServerError();
            return Ok();
        }
    }
}

