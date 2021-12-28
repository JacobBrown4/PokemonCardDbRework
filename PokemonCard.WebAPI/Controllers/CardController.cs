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
    [RoutePrefix("api/card")]
    public class CardController : ApiController
    {
        private CardService CreateCardService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cardService = new CardService(userId);
            return cardService;
        }

        public IHttpActionResult Get()
        {
            CardService cardService = CreateCardService();
            var cards = cardService.GetCards();
            return Ok(cards);
        }
        [Route("alphabetical")]
        public IHttpActionResult GetByName()
        {
            CardService cardService = CreateCardService();
            var cards = cardService.GetCardsByName();
            return Ok(cards);
        }
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            CardService cardService = CreateCardService();
            var card = cardService.GetCardById(id);
            return Ok(card);
        }
        [Route("holo")]
        public IHttpActionResult GetHolos()
        {
            CardService cardService = CreateCardService();
            var card = cardService.GetHolos();
            return Ok(card);
        }
        [Route("byrarity/{rarity}")]
        public IHttpActionResult GetByRarity(string rarity)
        {
            Rarity result;
            if (Enum.TryParse<Rarity>(rarity, out result))
            {
                CardService cardService = CreateCardService();
                var cards = cardService.GetCardsByRarity(result);
                return Ok(cards);
            }
            return BadRequest("Rarity type not found");
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCardService();

            if (!service.DeleteCard(id))
                return InternalServerError();

            return Ok();
        }
    }
}
