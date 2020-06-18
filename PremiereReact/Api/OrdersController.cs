using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using CommonModels;
using CommonModels.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PremiereServer.Api
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly AppDbContext _db;

        public OrdersController(AppDbContext db)
        {
            _db = db;
        }

        // POST api/<controller>
        [HttpPost("create")]
        public async Task Create([FromBody] Order order)
        {
            var session = await _db.Sessions.FirstOrDefaultAsync(x => x.Id == order.SessionId);
            if (session == null)
                NotFound(404);
            order.Session = session;
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            Ok(200);
        }
    }
}
