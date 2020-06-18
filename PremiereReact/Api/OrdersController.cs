using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CommonModels;
using Microsoft.EntityFrameworkCore;

namespace PremiereReact.Api
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
