using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PremiereServer;
using PremiereServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremiereReact.Api
{
    [Route("api/session")]
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
