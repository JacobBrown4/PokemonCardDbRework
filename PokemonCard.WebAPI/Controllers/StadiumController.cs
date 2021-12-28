using Microsoft.AspNet.Identity;
using PokemonCard.Data;
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
    [Authorize]
    [RoutePrefix("api/stadium")]
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
        [Route("byrarity/{rarity}")]
        public IHttpActionResult GetByRarity(string rarity)
        {
            Rarity result;
            if (Enum.TryParse<Rarity>(rarity, out result))
            {
                StadiumService stadiumService = CreateStadiumService();
                var stadiums = stadiumService.GetStadiumsByRarity(result);
                return Ok(stadiums);
            }
            return BadRequest("Rarity type not found");
        }
        [Route("{id}")]
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
