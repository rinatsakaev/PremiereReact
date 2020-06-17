using System.Linq;
using CommonModels;
using CommonModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PremiereServer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremiereReact.Api
{
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private readonly AppDbContext _db;
        public SessionController(AppDbContext db)
        {
            _db = db;
        }
        // GET: api/<controller>
        [HttpGet("get")]
        public string Get()
        {
            return JsonConvert.SerializeObject(
                _db.Sessions
                    .Include(x => x.Film)
                    .ToList()
            );
        }

        [HttpGet("getByFilmId/{filmId}")]
        public string GetByFilmId(int filmId)
        {
            return JsonConvert.SerializeObject(_db.Sessions
                .Include(x => x.Film)
                .Where(x => x.Film.Id == filmId).ToList());
        }

        [HttpGet("delete/{sessionId}")]
        public IActionResult Delete(int sessionId)
        {
            var session = _db.Sessions.FirstOrDefault(x => x.Id == sessionId);
            if (session == null)
                return NotFound();
            _db.Sessions.Remove(session);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Session session)
        {
            var film = _db.Films.Include(x=>x.Sessions)
                .FirstOrDefault(x => x.Id == session.Film.Id);
            if (film == null)
                return NotFound();
            session.Film = film;
            film.Sessions.Add(session);
            _db.SaveChanges();
            return Ok();
        }
    }
}
