using BusinessObjects;
using DataAccessObjects;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts()
            => ProductDAO.Instance.GetProducts();

        public Product? GetProductById(int id)
            => ProductDAO.Instance.GetProductById(id);

        public void AddProduct(Product product)
            => ProductDAO.Instance.AddProduct(product);

        public void UpdateProduct(Product product)
            => ProductDAO.Instance.UpdateProduct(product);

        public void DeleteProduct(int id)
            => ProductDAO.Instance.DeleteProduct(id);

        public List<Product> SearchProducts(string keyword)
            => ProductDAO.Instance.SearchProducts(keyword);
    }
}
