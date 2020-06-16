using Microsoft.AspNetCore.Mvc;
using PremiereReact.Models;
using PremiereServer;
using System;

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
        public IActionResult Create(string pageSlug)
        {
            _db.Likes.Add(
                new Like
                {
                    PageSlug = pageSlug,
                    DateTime = DateTime.Now
                });
            _db.SaveChanges();
            return Ok();
        }
    }
}
