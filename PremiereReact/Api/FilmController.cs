using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PremiereServer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremiereReact.Api
{
    [Route("api/[controller]")]
    public class FilmController : Controller
    {
        private readonly AppDbContext _db;
        public FilmController(AppDbContext db)
        {
            _db = db;
        }
        // GET: api/<controller>
        [HttpGet("get")]
        public string Get()
        {
            return JsonConvert.SerializeObject(
                _db.Films.ToList()
            );
        }
    }
}
