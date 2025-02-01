using Microsoft.AspNetCore.Mvc;
using OnlineShop.Model.Models;
using OnlineShop.service.Interface.GenericRipository;
using OnlineShop.service.Interface.ProductRepository;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IGenericInterface<Product> _product) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts(string? brand, string? type)
        {
            var products = await _product.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _product.GetById(id);   
            if (product == null) return NotFound();         
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _product.Add(product); 

                if (await _product.Save())
                {
                    return CreatedAtAction("GetProductById", new { id = product.Id }, product);
                }
            }

            return BadRequest(ModelState); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            _product.Update(product);
            await _product.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var product = await _product.GetById(id);
            if (product == null) return NotFound();
            
            _product.Delete(product);
            await _product.Save();
            return NoContent();
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> BrandListAsync()
        {
            //var products = await _product.GetBrandsAsync();
            return Ok();
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> TypeListAsync()
        {
            //var types = await _product.GetProductTypesAsync();
            return Ok();
        }

        private bool ProductExists(int id)
        {
            return _product.IsExist(id);
        }
    }
}