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
        public void Create(int filmId, DateTime dateTime)
        {
            var film = _db.Films.FirstOrDefault(x => x.Id == filmId);
            if (film == null)
                NotFound(404);
            var session = new Session{Film = film, StartTime = dateTime};
            _db.Sessions.AddAsync(session);
            Ok(200);
        }
    }
}
