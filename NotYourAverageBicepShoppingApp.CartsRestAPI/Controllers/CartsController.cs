using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotYourAverageBicepShoppingApp.CartsRestAPI.Models;

namespace NotYourAverageBicepShoppingApp.CartsRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : Controller
    {
        private readonly CartsNyabContext _cartContext;
        private readonly ProductsNyabContext _productContext;


        public CartsController(CartsNyabContext cartContext, ProductsNyabContext productContext)
        {
            _cartContext = cartContext;
            _productContext = productContext;
        }


        [HttpPost]
        public async Task<ActionResult<Cart>> CreateCart()
        {
            try
            {
                Cart cart = new Cart() { CartItems = new List<CartItem>(), CartPrice = 0.0m };
                _cartContext.Carts.Add(cart);
                await _cartContext.SaveChangesAsync();
                var result = this.CreatedAtAction("ReadCartByCartId", new { CartId = cart.CartId }, cart);
                return this.Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }

        }

        [HttpGet]
        public async Task<ActionResult<Cart>> ReadAllCarts()
        {
            try
            {
                var allCarts = await _cartContext.Carts.ToListAsync();
                if (!object.ReferenceEquals(allCarts, null))
                {
                    return this.Ok(allCarts);
                }
                return this.NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{cartId}")]
        public async Task<ActionResult<Cart>>? ReadCartByCartId(int cartId)
        {
            try
            {
                var foundCart = await _cartContext.Carts.FindAsync(cartId);
                if (object.ReferenceEquals(foundCart, null))
                {
                    return this.NotFound();

                }
                var cartItems = await _cartContext.CartItems
                    .Where(item => item.FkCartId == cartId)
                    .ToListAsync();
                var productIds = cartItems.Select(item => item.ProductId);
                var products = await _productContext.Products
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
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }

        }

        [HttpPut("{cartId}/add-product/{productId}")]
        public async Task<ActionResult<Cart>> UpdateCartAddProduct(int cartId, int productId)
        {
            try
            {
                var existingProduct = await _productContext.Products.FindAsync(productId);
                if (object.ReferenceEquals(existingProduct, null))
                {
                    return this.NotFound();
                }
                else
                {
                    CartItem newCartItem = new CartItem() { ProductId = productId, FkCartId = cartId };
                    _cartContext.CartItems.Add(newCartItem);

                    var existingCart = await _cartContext.Carts.FindAsync(cartId);
                    if (object.ReferenceEquals(existingCart, null))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        if (object.ReferenceEquals(existingCart.CartPrice, null))
                        {
                            existingCart.CartPrice = existingProduct.ProductPrice;
                            await _cartContext.SaveChangesAsync();
                            return this.Ok(existingCart);
                        }
                        else
                        {
                            existingCart.CartPrice += existingProduct.ProductPrice;
                            await _cartContext.SaveChangesAsync();
                            return this.Ok(existingCart);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }   

        [HttpPut("{cartId}/remove-product/{productId}")]
        public async Task<ActionResult<CartItem>> UpdateCartRemoveProduct(int cartId, int productId)
        {
            try
            {


            var existingCartItems = await _cartContext.CartItems
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
                    _cartContext.CartItems.Remove(existingCartItem);
                    var existingCart = await _cartContext.Carts.FindAsync(cartId);
                    var existingProduct = await _productContext.Products.FindAsync(productId);
                    existingCart.CartPrice -= existingProduct.ProductPrice;


                }
                await _cartContext.SaveChangesAsync();
                return this.Ok(existingCartItems);

            }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("clear-items/{cartId}")]
        public async Task<ActionResult<CartItem>> UpdateCartClearAllCartItems(int cartId)
        {
            try
            {
                var existingCartItems = await _cartContext.CartItems
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
                        _cartContext.CartItems.Remove(existingCartItem);
                        var existingCart = await _cartContext.Carts.FindAsync(cartId);
                        var existingProduct = await _productContext.Products.FindAsync(existingCartItem.ProductId);
                        existingCart.CartPrice -= existingProduct.ProductPrice;
                    }
                    await _cartContext.SaveChangesAsync();
                    return this.Ok(existingCartItems);

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }


        }

        [HttpDelete("{cartId}")]
        public async Task<ActionResult<Cart>> DeleteCart(int cartId)
        {
            try
            {
                var foundCart = await _cartContext.Carts.FindAsync(cartId);
                if (object.ReferenceEquals(foundCart, null))
                {
                    return this.NotFound();

                }
                _cartContext.Carts.Remove(foundCart);
                await _cartContext.SaveChangesAsync();
                return this.Ok(foundCart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }



    }



 }
