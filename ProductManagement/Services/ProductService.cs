using BusinessObjects;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public List<Product> GetProducts()
            => _productRepository.GetProducts();

        public Product? GetProductById(int id)
            => _productRepository.GetProductById(id);

        public void AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new ArgumentException("Product name cannot be empty.");
            if (product.Price < 0)
                throw new ArgumentException("Price cannot be negative.");
            if (product.UnitsInStock < 0)
                throw new ArgumentException("Units in stock cannot be negative.");

            _productRepository.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new ArgumentException("Product name cannot be empty.");
            if (product.Price < 0)
                throw new ArgumentException("Price cannot be negative.");
            if (product.UnitsInStock < 0)
                throw new ArgumentException("Units in stock cannot be negative.");

            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
            => _productRepository.DeleteProduct(id);

        public List<Product> SearchProducts(string keyword)
            => _productRepository.SearchProducts(keyword);
    }
}
