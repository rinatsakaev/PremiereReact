using Microsoft.AspNetCore.Mvc;
using PremiereReact.Models;
using PremiereServer;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
