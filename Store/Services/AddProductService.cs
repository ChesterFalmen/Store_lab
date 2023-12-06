using Store.Data;
using Store.Interfaces;

namespace Store.Services
{
    public class AddProductService : IAddProductService
    {
        public AppDbContext context;
        public AddProductService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddProduct(ProductInfo productInfo)
        {
            productInfo.Product.Producer = productInfo.Producer;
            productInfo.Product.Category = productInfo.Category;

            context.Add(productInfo.Producer);
            context.Add(productInfo.Category);
            context.Add(productInfo.Product);
            context.SaveChanges();
        }
    }
}
