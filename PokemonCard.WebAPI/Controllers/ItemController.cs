﻿using Microsoft.AspNet.Identity;
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
    [RoutePrefix("api/item")]
    public class ItemController : ApiController
    {
        private ItemService CreateItemService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var itemService = new ItemService(userID);
            return itemService;
        }
        public IHttpActionResult Get()
        {
            ItemService itemService = CreateItemService();
            var items = itemService.GetItems();
            return Ok(items);
        }
        public IHttpActionResult Get(int id)
        {
            ItemService itemService = CreateItemService();
            var item = itemService.GetItemByID(id);
            return Ok(item);
        }
        [Route("byrarity/{rarity}")]
        public IHttpActionResult GetByRarity(string rarity)
        {
            Rarity result;
            if (Enum.TryParse<Rarity>(rarity, out result))
            {
                ItemService itemService = CreateItemService();
                var items = itemService.GetItemsByRarity(result);
                return Ok(items);
            }
            return BadRequest("Rarity type not found");
        }
        public IHttpActionResult Post(ItemCreate item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateItemService();
            if (!service.CreateItem(item))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Put(ItemEdit item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateItemService();
            if (!service.UpdateItem(item))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateItemService();
            if (!service.DeleteItem(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
