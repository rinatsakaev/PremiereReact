using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PremiereServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremiereServer.Api
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
        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(
                _db.Sessions
                    .Include(x => x.Film)
                    .ToList()
            );
        }

        [HttpPost]
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
