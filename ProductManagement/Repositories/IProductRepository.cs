using BusinessObjects;

namespace Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        List<Product> SearchProducts(string keyword);
    }
}
