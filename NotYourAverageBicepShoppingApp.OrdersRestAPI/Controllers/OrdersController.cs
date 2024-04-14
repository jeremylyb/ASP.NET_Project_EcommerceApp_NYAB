using Microsoft.AspNetCore.Mvc;
using NotYourAverageBicepShoppingApp.OrdersRestAPI.Models;

namespace NotYourAverageBicepShoppingApp.OrderRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly NotYourAverageBicepContext _context;

        public OrdersController(NotYourAverageBicepContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order order)
        {
            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return this.CreatedAtAction("ReadOrderByOrderId", new { orderId = order.OrderId }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }

        }


        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>>? ReadOrderByOrderId(int orderId)
        {
            try
            {
                var foundOrder = await _context.Orders.FindAsync(orderId);
                if (object.ReferenceEquals(foundOrder, null))
                {
                    return this.NotFound();

                }
                return this.Ok(foundOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }



        }
    }
}
