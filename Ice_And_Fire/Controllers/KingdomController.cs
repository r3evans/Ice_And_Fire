using IAF.Model.Kingdom.m;
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
    public class KingdomController : ApiController
    {
        private KingdomService CreateKingdomService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var kingdomService = new KingdomService(userId);
            return kingdomService;
        }
        public IHttpActionResult Get()
        {
            KingdomService kingdomService = CreateKingdomService();
            var kingdoms = kingdomService.GetKingdoms();
            return Ok(kingdoms);
        }
        public IHttpActionResult Post(KingdomCreate kingdom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateKingdomService();
            if (!service.CreateKingdom(kingdom))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(Guid id)
        {
            KingdomService kingdomService = CreateKingdomService();
            var kingdoms = kingdomService.GetKingdoms(); return Ok(kingdoms);
        }
        public IHttpActionResult Put(KingdomEdit kingdom)  //update kingdom
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateKingdomService();
            if (!service.UpdateKingdom(kingdom))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult DeleteKingdom(Guid id)
        {
            var service = CreateKingdomService();
            if (!service.DeleteKingdom(id))
                return InternalServerError();
            return Ok();
        }
    }
}
}
