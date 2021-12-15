using Microsoft.AspNet.Identity;
using PokemonCard.Models;
using PokemonCard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PokemonCard.WebAPI.Controllers
{
    public class StadiumController : ApiController
    {
        private StadiumService CreateStadiumService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var stadiumService = new StadiumService(userID);
            return stadiumService;
        }
        public IHttpActionResult Get()
        {
            StadiumService stadiumService = CreateStadiumService();
            var stadiums = stadiumService.GetStadiums();
            return Ok(stadiums);
        }
        public IHttpActionResult Get(int id)
        {
            StadiumService stadiumService = CreateStadiumService();
            var stadiums = stadiumService.GetStadiumByID(id);
            return Ok(stadiums);
        }
        public IHttpActionResult Post(StadiumCreate stadium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateStadiumService(); ;
            if (!service.CreateStadium(stadium))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Put(StadiumEdit stadium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateStadiumService();

            if (!service.UpdateStadium(stadium))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateStadiumService();
            if (!service.DeleteStadium(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
