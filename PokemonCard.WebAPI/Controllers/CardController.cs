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

        public IHttpActionResult Get(int id)
        {
            CardService cardService = CreateCardService();
            var card = cardService.GetCardById(id);
            return Ok(card);
        }

        public IHttpActionResult Post(CardCreate card)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCardService();

            if (!service.CreateCard(card))
                return InternalServerError();

            return Ok();
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
