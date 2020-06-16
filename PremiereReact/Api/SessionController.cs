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
        public void Create([FromBody] Session session1)
        {
            var film = _db.Films.FirstOrDefault(x => x.Id == session1.Film.Id);
            if (film == null)
                NotFound(404);
            film.Sessions.Add(new Session { Film = film, StartTime = session1.StartTime }); _db.SaveChanges();
            _db.SaveChanges();
            Ok(200);
        }
    }
}
