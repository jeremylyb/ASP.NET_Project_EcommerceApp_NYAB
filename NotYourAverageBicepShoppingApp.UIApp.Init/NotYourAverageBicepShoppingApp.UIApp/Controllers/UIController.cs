using Microsoft.AspNetCore.Mvc;
using NotYourAverageBicepShoppingApp.UIApp.APIClient;
using NotYourAverageBicepShoppingApp.UIApp.Models;

namespace NotYourAverageBicepShoppingApp.UIApp.Controllers
{
    public class UIController : Controller
    {

        private readonly IProductsClient _productsClient;
        private readonly ICartsClient _cartsClient;
        private readonly IOrdersClient _ordersClient;

        public UIController(IProductsClient productsClient, ICartsClient cartsClient, IOrdersClient orderClient)
        {
            _productsClient = productsClient;
            _cartsClient = cartsClient;
            _ordersClient = orderClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        //************************ Products Related MVC Controller Methods ******************************************
        public async Task<IActionResult> AllProducts(string searchStr)
        {
            try
            {
                var products = await _productsClient.GetAllProductsAsync();
                if (!string.IsNullOrWhiteSpace(searchStr))
                {

                    var filteredProducts = products?.Where(product => product.ProductName.Contains(searchStr)).OrderBy(product => product.ProductName).ToList();
                    products = filteredProducts.ToList();
                }
                return View(products);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"HTTP request error occurred while fetching products: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching products: {ex.Message}");
            }
        }

        public async Task<IActionResult> OneProduct(string id)
        {
            try
            {
                var product = await _productsClient.GetProductByIdAsync(id);
                return View(product);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"HTTP request error occurred while fetching product: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching product: {ex.Message}");
            }
        }

        //************************ Cart Related MVC Controller Methods ******************************************
        public async Task<IActionResult> NewCart()
        {
            try
            {
                var cart = await _cartsClient.PostNewCartAsync();
                HttpContext.Session.SetString("CartId", cart.CartId.ToString());
                return View(cart);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"HTTP request error occurred while creating new cart: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating new cart: {ex.Message}");
            }

        }

        public async Task<IActionResult> ViewCart()
        {
            try
            {
                string? cartIdString = HttpContext.Session.GetString("CartId");
                int.TryParse(cartIdString, out int cartId);
                var cartDetailsDTO = await _cartsClient.GetAllCartItemsForCartAsync(cartId);
                return View(cartDetailsDTO);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"HTTP request error occurred while fetching cart details: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching cart details: {ex.Message}");
            }
        }

        public async Task<IActionResult> DeleteProductFromCart(int productId)
        {
            try
            {
                string? cartIdString = HttpContext.Session.GetString("CartId");
                int.TryParse(cartIdString, out int cartId);
                await _cartsClient.PutDeleteProductFromCartAsync(cartId, productId);
                return RedirectToAction(nameof(ViewCart));
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"HTTP request error occurred while deleting product from cart: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting product from cart: {ex.Message}");
            }

        }

        public async Task<IActionResult> AddProductToCart(int productId, int quantity)
        {
            string? cartIdString = HttpContext.Session.GetString("CartId");
            try
            {
                int.TryParse(cartIdString, out int cartId);
                await _cartsClient.PutAddProductToCartAsync(cartId, productId, quantity);
                return RedirectToAction(nameof(ViewCart));
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"HTTP request error occurred while adding product to cart: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding product to cart: {ex.Message}");
            }

        }

        public async Task<IActionResult> DeleteAllProductsFromCart()
        {
            try
            {
                string? cartIdString = HttpContext.Session.GetString("CartId");
                int.TryParse(cartIdString, out int cartId);
                await _cartsClient.PutDeleteAllProductsFromCartAsync(cartId);
                return RedirectToAction(nameof(ViewCart));
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"HTTP request error occurred while deleting all products from cart: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting all products from cart: {ex.Message}");
            }


        }


        //************************ Orders Related MVC Controller Methods ******************************************
        public IActionResult NewOrderBefore()
        {
            return View();
        }

        public async Task<IActionResult> NewOrderAfter([Bind("CustomerName")] Order order)
        {
            try
            {
                string cartIdString = HttpContext.Session.GetString("CartId");
                int.TryParse(cartIdString, out int cartId);
                order.CartId = cartId;
                order = await _ordersClient.PostOrders(order);
                var cartDetailsDTO = await _cartsClient.GetAllCartItemsForCartAsync(cartId);
                var orderAndCartItems = new OrderAndCartItems() { Order = order, CartDetailsDTO = cartDetailsDTO };
                return View(orderAndCartItems);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"HTTP request error occurred while creating new order: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating new order: {ex.Message}");
            }


        }


    }


}
