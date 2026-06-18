using BusinessObjects;

namespace DataAccessObjects
{
    /// <summary>
    /// In-memory data store that simulates a database.
    /// Replace this with EF Core MyStoreContext when a real DB is available.
    /// </summary>
    public static class MyStoreContext
    {
        public static List<Category> Categories { get; private set; }
        public static List<Product> Products { get; private set; }
        public static List<AccountMember> Accounts { get; private set; }

        static MyStoreContext()
        {
            Categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Electronics" },
                new Category { CategoryId = 2, CategoryName = "Clothing" },
                new Category { CategoryId = 3, CategoryName = "Food & Beverage" },
                new Category { CategoryId = 4, CategoryName = "Books" },
            };

            Products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Laptop Pro 15", Price = 1299.99m, UnitsInStock = 10, CategoryId = 1 },
                new Product { ProductId = 2, ProductName = "Wireless Headphones", Price = 89.99m, UnitsInStock = 25, CategoryId = 1 },
                new Product { ProductId = 3, ProductName = "USB-C Hub", Price = 39.99m, UnitsInStock = 50, CategoryId = 1 },
                new Product { ProductId = 4, ProductName = "Cotton T-Shirt", Price = 19.99m, UnitsInStock = 100, CategoryId = 2 },
                new Product { ProductId = 5, ProductName = "Running Shoes", Price = 79.99m, UnitsInStock = 30, CategoryId = 2 },
                new Product { ProductId = 6, ProductName = "Green Tea Pack", Price = 12.99m, UnitsInStock = 200, CategoryId = 3 },
                new Product { ProductId = 7, ProductName = "C# Programming Book", Price = 45.00m, UnitsInStock = 15, CategoryId = 4 },
            };

            // Link categories to products
            foreach (var p in Products)
                p.Category = Categories.FirstOrDefault(c => c.CategoryId == p.CategoryId);

            Accounts = new List<AccountMember>
            {
                new AccountMember { AccountId = 1, Email = "admin@store.com", Password = "admin123", FullName = "Administrator", Role = 1 },
                new AccountMember { AccountId = 2, Email = "staff@store.com", Password = "staff123", FullName = "Staff Member", Role = 2 },
            };
        }

        private static int _nextProductId = 8;
        public static int GetNextProductId() => _nextProductId++;
    }
}
