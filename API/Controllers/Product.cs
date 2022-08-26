using Data.Abstract;
using Data.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product : Controller
    {
        private IProductService _product;
        public Product()
        {
            _product = new ProductService();
        }
        [HttpGet]
        public List<Data.Entities.Product> Get()
        {
            return _product.GetAllProduct();
        }
        [HttpGet("{Id}")]
        public Data.Entities.Product Get(int Id)
        {
            return _product.GetProductId(Id);

        }
        [HttpPost]
        public Data.Entities.Product Post([FromBody] Data.Entities.Product product)
        {
            return _product.CreateProduct(product);

        }

        [HttpPut]
        public Data.Entities.Product Put([FromBody] Data.Entities.Product product)
        {
            return _product.UpdateProduct(product);

        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _product.DeleteProduct(Id);

        }
    }
}
