using IAF.Model.Estate.m;
using IAF.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ice_And_Fire.Controllers
{
    public class EstateController : ApiController
    {
        private EstateService CreateEstateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var estateService = new EstateService(userId);
            return estateService;
        }
        public IHttpActionResult Get()
        {
            EstateService estateService = CreateEstateService();
            var estates = estateService.GetEstates();
            return Ok(estates);
        }
        public IHttpActionResult Post(EstateCreate estate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateEstateService();
            if (!service.CreateEstate(estate))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(Guid id)
        {
            EstateService estateService = CreateEstateService();
            var estate = estateService.GetEstateById(id);
            return Ok(estate);
        }
        public IHttpActionResult Put(EstateEdit estate)  //update estate
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateEstateService();
            if (!service.UpdateEstate(estate))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult DeleteEstate(Guid id)
        {
            var service = CreateEstateService();
            if (!service.DeleteEstate(id))
                return InternalServerError();
            return Ok();
        }
    }
}

