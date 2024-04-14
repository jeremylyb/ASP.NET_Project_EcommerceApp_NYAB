using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NotYourAverageBicepShoppingApp.CartsRestAPI.Models;

namespace NotYourAverageBicepShoppingApp.CartsRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : Controller
    {
        private readonly NotYourAverageBicepContext _context;

        public CartsController(NotYourAverageBicepContext NYABContext)
        {
            _context =  NYABContext;
        }


        [HttpPost]
        public async Task<ActionResult<Cart?>> CreateCart()
        {
            try
            {
                Cart cart = new Cart() { CartItems = new List<CartItem>(), CartPrice = 0.0m };
                _context.Carts.Add(cart);
                var output = await _context.SaveChangesAsync();
                Console.WriteLine($"LinesImpacted: { output}");
                var result = this.CreatedAtAction("ReadCartByCartId", new { CartId = cart.CartId }, cart);
                return this.Ok(cart);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database error occurred: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Invalid operation: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred: {ex.Message}");
            }

        }

        [HttpGet]
        public async Task<ActionResult<Cart?>> ReadAllCarts()
        {
            try
            {
                var allCarts = await _context.Carts.ToListAsync();
                if (!object.ReferenceEquals(allCarts, null))
                {
                    return this.Ok(allCarts);
                }
                return this.NotFound();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database error occurred: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Invalid operation: {ex.Message}");
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
            catch (TimeoutException ex)
            {
                return StatusCode(500, $"The operation timed out: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }

        [HttpGet("{cartId}")]
        public async Task<ActionResult<Cart?>> ReadCartByCartId(int cartId)
        {
            try
            {
                var foundCart = await _context.Carts.FindAsync(cartId);
                if (object.ReferenceEquals(foundCart, null))
                {
                    return this.NotFound();

                }
                var cartItems = await _context.CartItems
                    .Where(item => item.FkCartId == cartId)
                    .ToListAsync();
                var productIds = cartItems.Select(item => item.ProductId);
                var products = await _context.Products
                    .Where(product => productIds.Contains(product.ProductId))
                    .ToListAsync();
                var cartItemsWithProducts = cartItems.Select(cartItem =>
                {
                    var product = products.FirstOrDefault(p => p.ProductId == cartItem.ProductId);
                    return new CartItemWithProduct
                    {
                        CartItem = cartItem,
                        Product = product
                    };
                }).ToList();

                var cartDetailsDTO = new CartDetailsDTO
                {
                    Cart = foundCart,
                    CartItemsWithProducts = cartItemsWithProducts
                };

                return this.Ok(cartDetailsDTO);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database error occurred: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Invalid operation: {ex.Message}");
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
            catch (TimeoutException ex)
            {
                return StatusCode(500, $"The operation timed out: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }

        }

        [HttpPut("{cartId}/add-product/{productId}/{quantity}")]
        public async Task<ActionResult<Cart?>> UpdateCartAddProduct(int cartId, int productId, int quantity)
        {
            try
            {
                var existingProduct = await _context.Products.FindAsync(productId);
                if (object.ReferenceEquals(existingProduct, null))
                {
                    return this.NotFound();
                }
                else
                {
                    var existingCartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.ProductId == productId && c.FkCartId == cartId);

                    if (object.ReferenceEquals(existingCartItem, null))
                    {
                        CartItem newCartItem = new CartItem() { ProductId = productId, FkCartId = cartId, Quantity = quantity };
                        _context.CartItems.Add(newCartItem);
                        var existingCart = await _context.Carts.FindAsync(cartId);
                        if (object.ReferenceEquals(existingCart, null))
                        {
                            return this.NotFound();
                        }
                        else
                        {
                            if (object.ReferenceEquals(existingCart.CartPrice, null))
                            {
                                existingCart.CartPrice = existingProduct.ProductPrice * quantity;
                                await _context.SaveChangesAsync();
                                return this.Ok(existingCart);
                            }
                            else
                            {
                                for (int i = 0; i < quantity; i++)
                                {
                                    existingCart.CartPrice += existingProduct.ProductPrice;
                                }
                                await _context.SaveChangesAsync();
                                return this.Ok(existingCart);
                            }
                        }
                    }
                    else
                    {
                        existingCartItem.Quantity += quantity;
                        var existingCart = await _context.Carts.FindAsync(cartId);
                        if (object.ReferenceEquals(existingCart, null))
                        {
                            return this.NotFound();
                        }
                        else
                        {
                            if (object.ReferenceEquals(existingCart.CartPrice, null))
                            {
                                existingCart.CartPrice = existingProduct.ProductPrice * quantity;
                                await _context.SaveChangesAsync();
                                return this.Ok(existingCart);
                            }
                            else
                            {
                                for (int i = 0; i < quantity; i++)
                                {
                                    existingCart.CartPrice += existingProduct.ProductPrice;
                                }
                                await _context.SaveChangesAsync();
                                return this.Ok(existingCart);
                            }
                        }
                    }

                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database error occurred: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Invalid operation: {ex.Message}");
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
            catch (TimeoutException ex)
            {
                return StatusCode(500, $"The operation timed out: {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"An error occurred while processing your request: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }

        [HttpPut("{cartId}/reduce-product/{productId}/{quantity}")]
        public async Task<ActionResult<Cart?>> UpdateCartReduceProduct(int cartId, int productId, int quantity)
        {
            try
            {
                var existingProduct = await _context.Products.FindAsync(productId);
                if (object.ReferenceEquals(existingProduct, null))
                {
                    return this.NotFound();
                }
                else
                {
                    var existingCartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.ProductId == productId && c.FkCartId == cartId);
                    existingCartItem.Quantity -= quantity;
                    var existingCart = await _context.Carts.FindAsync(cartId);
                    if (object.ReferenceEquals(existingCart, null))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        if (object.ReferenceEquals(existingCart.CartPrice, null))
                        {
                            existingCart.CartPrice = existingProduct.ProductPrice * quantity;
                            await _context.SaveChangesAsync();
                            return this.Ok(existingCart);
                        }
                        else
                        {
                            for (int i = 0; i < quantity; i++)
                            {
                                existingCart.CartPrice -= existingProduct.ProductPrice;
                            }

                            await _context.SaveChangesAsync();
                            return this.Ok(existingCart);
                        }
                    }


                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database error occurred: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Invalid operation: {ex.Message}");
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
            catch (TimeoutException ex)
            {
                return StatusCode(500, $"The operation timed out: {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"An error occurred while processing your request: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }

        [HttpPut("{cartId}/remove-product/{productId}")]
        public async Task<ActionResult<CartItem?>> UpdateCartRemoveProduct(int cartId, int productId)
        {
            try
            {
                var existingCartItems = await _context.CartItems
                                .Where(item => item.FkCartId == cartId && item.ProductId == productId)
                                .ToListAsync();


                if (object.ReferenceEquals(existingCartItems, null))
                {
                    return this.NotFound();
                }
                else
                {
                    foreach (var existingCartItem in existingCartItems)
                    {
                        _context.CartItems.Remove(existingCartItem);
                        var existingCart = await _context.Carts.FindAsync(cartId);
                        var existingProduct = await _context.Products.FindAsync(productId);
                        existingCart.CartPrice -= existingProduct.ProductPrice * existingCartItem.Quantity;
                    }
                    await _context.SaveChangesAsync();
                    return this.Ok(existingCartItems);

                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database error occurred: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Invalid operation: {ex.Message}");
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
            catch (TimeoutException ex)
            {
                return StatusCode(500, $"The operation timed out: {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"An error occurred while processing your request: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }

        [HttpPut("clear-items/{cartId}")]
        public async Task<ActionResult<CartItem?>> UpdateCartClearAllCartItems(int cartId)
        {
            try
            {
                var existingCartItems = await _context.CartItems
                                .Where(item => item.FkCartId == cartId)
                                .ToListAsync();
                if (object.ReferenceEquals(existingCartItems, null))
                {
                    return this.NotFound();
                }
                else
                {
                    foreach (var existingCartItem in existingCartItems)
                    {
                        _context.CartItems.Remove(existingCartItem);
                        var existingProduct = await _context.Products.FindAsync(existingCartItem.ProductId);

                    }
                    var existingCart = await _context.Carts.FindAsync(cartId);
                    existingCart.CartPrice = 0;
                    await _context.SaveChangesAsync();
                    return this.Ok(existingCartItems);

                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database error occurred: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Invalid operation: {ex.Message}");
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
            catch (TimeoutException ex)
            {
                return StatusCode(500, $"The operation timed out: {ex.Message}");
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"An error occurred while processing your request: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }


        }

        [HttpDelete("{cartId}")]
        public async Task<ActionResult<Cart?>> DeleteCart(int cartId)
        {
            try
            {
                var foundCart = await _context.Carts.FindAsync(cartId);
                if (object.ReferenceEquals(foundCart, null))
                {
                    return this.NotFound();

                }
                _context.Carts.Remove(foundCart);
                await _context.SaveChangesAsync();

                return this.Ok(foundCart);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Database error occurred: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Invalid operation: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}
