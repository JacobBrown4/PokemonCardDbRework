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
    [RoutePrefix("api/supporter")]
    public class SupporterController : ApiController
    {
        private SupporterService CreateSupporterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var supporterService = new SupporterService(userId);
            return supporterService;
        }
        public IHttpActionResult Get()
        {
            SupporterService supporterService = CreateSupporterService();
            var supporters = supporterService.GetSupporters();
            return Ok(supporters);
        }
        [Route("byrarity/{rarity}")]
        public IHttpActionResult GetByRarity(string rarity)
        {
            Rarity result;
            if (Enum.TryParse<Rarity>(rarity, out result))
            {
                SupporterService supporterService = CreateSupporterService();
                var supporters = supporterService.GetSupportersByRarity(result);
                return Ok(supporters);
            }
            return BadRequest("Rarity type not found");
        }
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            SupporterService supporterService = CreateSupporterService();
            var supporters = supporterService.GetSupporterByID(id);
            return Ok(supporters);
        }
        public IHttpActionResult Post(SupporterCreate supporter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateSupporterService();
            if (!service.CreateSupporter(supporter))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Put(SupporterEdit supporter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateSupporterService();
            if (!service.UpdateSupporter(supporter))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSupporterService();
            if (!service.DeleteSupporter(id))
            {
                return InternalServerError();
            }
            return Ok();
        }

    }
}
