﻿using Microsoft.AspNet.Identity;
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
    public class ToolController : ApiController
    {
        private ToolService CreateToolService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var toolService = new ToolService(userId);
            return toolService;
        }
        public IHttpActionResult Get()
        {
            ToolService toolService = CreateToolService();
            var tools = toolService.GetTools();
            return Ok(tools);
        }
        public IHttpActionResult Get(int id)
        {
            ToolService toolService = CreateToolService();
            var tools = toolService.GetToolByID(id);
            return Ok(tools);
        }
        public IHttpActionResult Post(ToolCreate tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateToolService();
            if (!service.CreateTool(tool))
            {
                return InternalServerError();   
            }
            return Ok();
        }
        public IHttpActionResult Put(ToolEdit tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateToolService();
            if (!service.UpdateTool(tool))
            {
                return InternalServerError();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateToolService();
            if (!service.DeleteTool(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
