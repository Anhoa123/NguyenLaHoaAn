using BusinessObjects;

namespace Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        List<Product> SearchProducts(string keyword);
    }
}
