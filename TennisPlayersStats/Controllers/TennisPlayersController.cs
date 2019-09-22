using Data.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TennisPlayersStats.Controllers
{

    [RoutePrefix("api/players")]
    public class TennisPlayerController : ApiController
    {
        private readonly ITennisPlayerRepository _repository;

        public TennisPlayerController()
        {
        }
        public TennisPlayerController(ITennisPlayerRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Get All players
        /// </summary>
        /// <returns>List of players</returns>
        [Route("")]
        [HttpGet]
        public IHttpActionResult Players()
        {
            return Ok(_repository.GetAll().ToList());
        }
        /// <summary>
        /// Get player by identifier
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns>player or not found exception</returns>
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Player(int id)
        {
            Player player = _repository.GetById(id);

            if (player == null)
                return NotFound();

            return Ok(player);
        }
        /// <summary>
        /// Delete player by identifier
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns>Ok action result or not found exception</returns>
        [Route("delete/{id}")]
        [HttpGet]
        public IHttpActionResult Delete(int id)
        {
            Player player = _repository.GetById(id);

            if (player == null)
                return NotFound();

            _repository.Delete(player);
            return Ok();
        }

    }
}
