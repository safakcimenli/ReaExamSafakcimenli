using Data.Abstract;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class ProductService : IProductService
    {
        Context context = new Context();
        
        public Product CreateProduct(Product Product)
        {
            using (var context = new Context())
            {
                context.Add(Product);
                context.SaveChanges();
                return Product;
            }
        }

        public void DeleteProduct(int id)
        {
           
                var deleteProduct = GetProductId(id);
                context.Product.Remove(deleteProduct);
                context.SaveChanges();
            
        }

        public List<Product> GetAllProduct()
        {
            
                return context.Product.ToList();
            
        }

        public Product GetProductId(int id)
        {
            
                return context.Product.Find(id);
            
        }

        public Product UpdateProduct(Product Product)
        {
            
                context.Product.Update(Product);
                context.SaveChanges();
                return Product;
            
        }

        
}
