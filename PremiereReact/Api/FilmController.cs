using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        public async Task<string> Get()
        {
            return JsonConvert.SerializeObject(
                await _db.Films.ToListAsync()
            );
        }
    }
}
