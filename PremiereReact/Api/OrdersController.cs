using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PremiereServer.Models;
using System.Linq;

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
        [HttpPost]
        public void Create(int sessionId, int quantity)
        {
            var session = _db.Sessions.FirstOrDefault(x => x.Id == sessionId);
            if (session == null)
                NotFound(404);
            var order = new Order { Quantity = quantity, Session = session };
            _db.Orders.AddAsync(order);
            Ok(200);
        }
    }
}
