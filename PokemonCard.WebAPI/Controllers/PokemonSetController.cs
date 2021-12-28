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
    [Authorize]
    [RoutePrefix("api/set")]
    public class PokemonSetController : ApiController
    {
        private SetService CreateSetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var setService = new SetService(userId);
            return setService;
        }
        public IHttpActionResult Get()
        {
            SetService setService = CreateSetService();
            var pokemonsSets = setService.GetPokemonSets();
            return Ok(pokemonsSets);
        }
        public IHttpActionResult Post(SetCreate pokemonSet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSetService();

            if (!service.CreateSet(pokemonSet))
                return InternalServerError();

            return Ok();
        }
        [Route("{id}")]

        public IHttpActionResult Get(int setId)
        {
            SetService setservice = CreateSetService();
            var pokemonset = setservice.GetSetBySetId(setId);
            return Ok(pokemonset);
        }
        public IHttpActionResult Put(SetEdit pokemonSet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSetService();

            if (!service.UpdateSet(pokemonSet))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSetService();

            if (!service.DeleteSet(id))
                return InternalServerError();

            return Ok();
        }
    }
}
