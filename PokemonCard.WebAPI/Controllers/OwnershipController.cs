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
    public class OwnershipController : ApiController
    {
        public IHttpActionResult Get()
        {
            OwnershipService ownershipService = CreateOwnerService();
            var owners = ownershipService.GetOwners();
            return Ok(owners);
        }
        public IHttpActionResult Post(OwnershipCreate owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateOwnerService();
            if (!service.CreateOwner(owner))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            OwnershipService ownershipService = CreateOwnerService();
            var owner = ownershipService.
        }
        private OwnershipService CreateOwnerService()
        {
            var ownderID = Guid.Parse(User.Identity.GetUserId());
            var ownerService = new OwnershipService(ownderID);
            return ownerService;
        }
    }
}
