namespace Store.Interfaces
{
    public interface IListProductsService
    {
        IEnumerable<ProductInfo> GetProducts();
    }
}
