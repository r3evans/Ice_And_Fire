using IAF.Data;
using IAF.Model.Region.m;
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
        public class RegionController : ApiController
        {
            private RegionService CreateRegionService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var regionService = new RegionService(userId);
                return regionService;
            }
            public IHttpActionResult Get()
            {
                RegionService regionService = CreateRegionService();
                var regions = regionService.GetRegions();
                return Ok(regions);
            }
            public IHttpActionResult Post(RegionCreate region)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var service = CreateRegionService();
                if (!service.CreateRegion(region))
                    return InternalServerError();
                return Ok();
            }
            public IHttpActionResult Get(int id)
            {
                RegionService regionService = CreateRegionService();
                var region = regionService.GetRegionById(id);
                return Ok(region);
            }
            public IHttpActionResult Put(RegionEdit region)  //update region
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var service = CreateRegionService();
                if (!service.UpdateRegion(region))
                {
                    return InternalServerError();
                }
                return Ok();
            }
            public IHttpActionResult DeleteRegion(int id)
            {
                var service = CreateRegionService();
                if (!service.DeleteRegion(id))
                    return InternalServerError();
                return Ok();
            }
        }
    }

