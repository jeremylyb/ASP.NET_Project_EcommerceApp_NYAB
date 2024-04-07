using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotYourAverageBicepShoppingApp.ProductsRestAPI.Models;

namespace NotYourAverageBicepShoppingApp.ProductRestApi.Controllers
{
    /// <summary>
    /// Controller for managing product-related operations in the Product REST API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {

        private readonly ProductsNyabContext _context;

        /// <summary>
        /// Initializes a new instance of the ProductController class with the specified ProductsAcmeContext.
        /// </summary>
        /// <param name="context">The ProductsAcmeContext instance.</param>
        public ProductsController(ProductsNyabContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>An <c>ActionResult</c> containing <see cref="IEnumerable{T}"/> of <see cref="Product"/> representing all products, or <see cref="NotFoundResult"/> if no products are found.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product?>>> ReadAllProducts()
        {
            try
            {
                var allProducts = await _context.Products.ToListAsync();
                if (!object.ReferenceEquals(allProducts, null))
                {
                    return this.Ok(allProducts);
                }
                return this.NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">An integer representing the ID of the product to retrieve.</param>
        /// <returns>
        /// An <see cref="ActionResult"/> containing a <see cref="Product"/> instance if found, or <see cref="NotFoundResult"/> if no product with the specified ID is found.
        /// </returns>
        [HttpGet("{productId}")]
        public async Task<ActionResult<Product?>> ReadProductByProductId(int productId)
        {
            try
            {
                var foundProduct = await _context.Products.FindAsync(productId);
                if (!object.ReferenceEquals(foundProduct, null))
                {
                    return this.Ok(foundProduct);

                }
                return this.NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all products by a specified product name.
        /// </summary>
        /// <param name="productName">A string representing the product name.</param>
        /// <returns>
        /// An <see cref="ActionResult"/> containing <see cref="IEnumerable{T}"/> of <see cref="Product"/> representing all products with the specified name, 
        /// or <see cref="NotFoundResult"/> if no products are found.
        /// </returns>
        [HttpGet("productName/{productName}")]
        public async Task<ActionResult<IEnumerable<Product?>>> ReadAllProductsByProductName(string productName)
        {
            try
            {
                var allProductsByProductName = await _context.Products.Where(p => p.ProductName == productName).ToListAsync();
                if (allProductsByProductName.Count > 0)
                {
                    return this.Ok(allProductsByProductName);

                }
                return this.NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>
        /// An <see cref="ActionResult"/> containing the created <see cref="Product"/> instance,
        /// or a <see cref="StatusCodeResult"/> with a status code of 500 if an error occurs.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<Product?>> CreateProduct([FromBody] Product product)
        {
            try
            {
                _context.Products.Add(product);
                var numberOfAffectedRows = await _context.SaveChangesAsync();
                return this.CreatedAtAction("ReadProductByProductId", new { productId = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="product">The product to update.</param>
        /// <returns>
        /// An <see cref="ActionResult"/> containing the updated <see cref="Product"/> instance,
        /// or <see cref="NotFoundResult"/> if no product with the specified ID is found.
        /// </returns>
        [HttpPut]
        public async Task<ActionResult<Product?>> UpdateProduct([FromBody] Product product)
        {
            try
            {
                var existingProduct = await _context.Products.FindAsync(product.ProductId);
                if (!object.ReferenceEquals(existingProduct, null))
                {
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.ProductPrice = product.ProductPrice;
                    await _context.SaveChangesAsync();
                    return this.Ok(existingProduct);
                }
                return this.NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }


        }


        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="productId">An integer representing the ID of the product to delete.</param>
        /// <returns>
        /// An <see cref="ActionResult"/> containing the deleted <see cref="Product"/> instance,
        /// or <see cref="NotFoundResult"/> if no product with the specified ID is found.
        /// </returns>
        [HttpDelete("{productId}")]
        public async Task<ActionResult<Product?>> DeleteProduct(int productId)
        {
            try
            {
                var foundProduct = await _context.Products.FindAsync(productId);
                if (!object.ReferenceEquals(foundProduct, null))
                {
                    _context.Products.Remove(foundProduct);
                    var numberOfAffectedRows = await _context.SaveChangesAsync();
                    return this.Ok(foundProduct);
                }
                return this.NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }

        }
    }
}
