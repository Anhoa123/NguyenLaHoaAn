using BusinessObjects;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        private static ProductDAO? _instance;
        public static ProductDAO Instance => _instance ??= new ProductDAO();

        private ProductDAO() { }

        public List<Product> GetProducts()
        {
            return MyStoreContext.Products
                .Select(p => new Product
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    UnitsInStock = p.UnitsInStock,
                    CategoryId = p.CategoryId,
                    Category = MyStoreContext.Categories.FirstOrDefault(c => c.CategoryId == p.CategoryId)
                })
                .ToList();
        }

        public Product? GetProductById(int id)
        {
            var p = MyStoreContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (p == null) return null;
            p.Category = MyStoreContext.Categories.FirstOrDefault(c => c.CategoryId == p.CategoryId);
            return p;
        }

        public void AddProduct(Product product)
        {
            product.ProductId = MyStoreContext.GetNextProductId();
            product.Category = MyStoreContext.Categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
            MyStoreContext.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existing = MyStoreContext.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existing == null) throw new Exception($"Product with ID {product.ProductId} not found.");

            existing.ProductName = product.ProductName;
            existing.Price = product.Price;
            existing.UnitsInStock = product.UnitsInStock;
            existing.CategoryId = product.CategoryId;
            existing.Category = MyStoreContext.Categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
        }

        public void DeleteProduct(int id)
        {
            var product = MyStoreContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) throw new Exception($"Product with ID {id} not found.");
            MyStoreContext.Products.Remove(product);
        }

        public List<Product> SearchProducts(string keyword)
        {
            return MyStoreContext.Products
                .Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
