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
    public class PokemonController : ApiController
    {
        private PokemonService CreatePokemonService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var pokemonService = new PokemonService(userID);
            return pokemonService;
        }
        public IHttpActionResult Get()
        {
            PokemonService pokemonService = CreatePokemonService();
            var pokemons = pokemonService.GetPokemons();
            return Ok(pokemons);
        }
        public IHttpActionResult Get(int id)
        {
            PokemonService pokemonService = CreatePokemonService();
            var pokemon = pokemonService.GetPokemonById(id);
            return Ok(pokemon);
        }
        public IHttpActionResult Post(PokemonCreate pokemon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreatePokemonService();
            if (!service.CreatePokemon(pokemon))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Put(PokemonEdit pokemon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreatePokemonService();
            if (!service.UpdatePokemon(pokemon))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePokemonService();

            if (!service.DeletePokemon(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
