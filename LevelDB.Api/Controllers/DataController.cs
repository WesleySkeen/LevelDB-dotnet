using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace LevelDB.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly LocalDb _localDb;

        public DataController(LocalDb localDb)
        {
            _localDb = localDb;
        }

        [HttpPost]
        public void Post()
        {
            populatePlayers();
        }

        [HttpGet]
        [Route("")]
        public Player Get()
        {
            populatePlayers();

            return _localDb.Get("Bruno");
        }

        [HttpGet]
        [Route("search/{id}")]
        public Player Get(string id)
        {
            return _localDb.Get(id);
        }

        private void populatePlayers()
        {
            var players = new List<Player>
            {
                new Player("Bruno", "Fernandez"),
                new Player("Anthony", "Martial"),
                new Player("Marcus", "Rashford")
            };

            _localDb.Put(players);
        }
    }
}