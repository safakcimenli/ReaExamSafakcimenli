using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IProductService
    {
        Product CreateProduct(Product Product);
        void DeleteProduct(int id);
        List<Product> GetAllProduct();
        Product GetProductId(int id);
        Product UpdateProduct(Product Product);
    }
}
