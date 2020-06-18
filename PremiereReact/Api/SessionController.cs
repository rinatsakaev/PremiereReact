using CommonModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PremiereServer;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<string> Get()
        {
            return JsonConvert.SerializeObject(
                await _db.Sessions
                    .Include(x => x.Film)
                    .ToListAsync()
            );
        }

        [HttpGet("getByFilmId/{filmId}")]
        public async Task<string> GetByFilmId(int filmId)
        {
            return JsonConvert.SerializeObject(await _db.Sessions
                .Include(x => x.Film)
                .Where(x => x.Film.Id == filmId).ToListAsync());
        }

        [HttpGet("delete/{sessionId}")]
        public async Task<IActionResult> Delete(int sessionId)
        {
            var session = await _db.Sessions.FirstOrDefaultAsync(x => x.Id == sessionId);
            if (session == null)
                return NotFound();
            _db.Sessions.Remove(session);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Session session)
        {
            var film = await _db.Films.Include(x => x.Sessions)
                .FirstOrDefaultAsync(x => x.Id == session.Film.Id);
            if (film == null)
                return NotFound();
            session.Film = film;
            film.Sessions.Add(session);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
