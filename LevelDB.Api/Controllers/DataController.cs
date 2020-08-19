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

        [HttpGet]
        [Route("")]
        public Player Get()
        {
            return _localDb.Get("Bruno");
        }

        [HttpGet]
        [Route("search/{id}")]
        public Player Get(string id)
        {
            return _localDb.Get(id);
        }
    }
}