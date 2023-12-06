using Store.Data;
using Store.Data.Models;
using Store.Interfaces;
using System.Linq;

namespace Store.Services
{
    public class ListProductsService : IListProductsService
    {
        public AppDbContext context;
        public ListProductsService(AppDbContext context)
        {
            this.context = context;
        }
       
        public IEnumerable<ProductInfo> GetProducts()
        {
            IEnumerable<ProductInfo> products = from product in context.Set<Product>()
                                               from producer in context.Set<Producer>()
                                               .Where(producer => producer.Id == product.ProducerId).DefaultIfEmpty()
                                               from category in context.Set<Category>()
                                               .Where(category => category.Id == product.CategoryId).DefaultIfEmpty()
                                               select new ProductInfo
                                               {
                                                   Product = product,
                                                   Category = category,
                                                   Producer = producer
                                               };
            return products;
        }
    }
}
