using Microsoft.AspNetCore.Mvc;
using PremiereReact.Models;
using System;
using System.Threading.Tasks;

namespace PremiereReact.Api
{
    [Route("api/[controller]")]
    public class LikesController : Controller
    {
        private readonly AppDbContext _db;

        public LikesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create(string pageSlug)
        {
            await _db.Likes.AddAsync(
                new Like
                {
                    PageSlug = pageSlug,
                    DateTime = DateTime.Now
                });
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
