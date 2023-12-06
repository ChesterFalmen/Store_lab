using Store.Data.Models;

namespace Store
{
    public class ProductInfo
    {
        public Product Product { get; set; } = new Product();
        public Producer Producer { get; set; } = new Producer();
        public Category Category { get; set; } = new Category();
    }
}
