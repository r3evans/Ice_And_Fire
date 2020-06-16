using IAF.Data;
using IAF.Model.UserEstate.m;
using IAF.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace Ice_And_Fire.Controllers
{
    public class UserEstateController : ApiController
    {
        private UserEstateService CreateUserEstateService() //Allows a user to create a favorites list and then add additional Estates to their favorites. Acts as both Create and Update
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userEstateService = new UserEstateService(userId);
            return userEstateService;
        }
        // public IHttpActionResult Get()
        // {
        //     UserEstateService userEstateService = CreateUserEstateService();
        //     var userEstates = userEstateService.GetFavoriteEstates();
        //      return Ok(userEstates);
        //  }
        public IHttpActionResult Post(UserEstateCreate userEstate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateUserEstateService();
            if (!service.CreateUserEstate(userEstate))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(int userId)
        {
            UserEstateService userEstateService = CreateUserEstateService();
            var userEstates = userEstateService.GetFavoriteEstates(userId);
            return Ok(userEstates);
        }
        //public IHttpActionResult Put (UserEstateEdit userEstate)    //this function is below 
        //  {                                                        
        //      if (!ModelState.IsValid)
        //      {
        //          return BadRequest(ModelState);
        //      }
        //      var service = CreateUserEstateService();
        //      if(!service.UpdateUserEstate(userEstate))
        //      {
        //          return InternalServerError();
        //      }
        //      return Ok();
        //  }

        public IHttpActionResult DeleteUserEstateByEstateId(int userId, int estateId)  //Edits a UserEstate or FavoriteEstates for a specific user, allowing them to remove a favorite estate.
        {
            var service = CreateUserEstateService();
            if (!service.DeleteUserEstateByEstateId(userId, estateId))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult DeleteUserEstate(int userId)
        {
            var service = CreateUserEstateService();
            if (!service.DeleteUserEstate(userId))
                return InternalServerError();
            return Ok();

        }
    }
}
