using BusinessObjects;

namespace DataAccessObjects
{
    public class CategoryDAO
    {
        private static CategoryDAO? _instance;
        public static CategoryDAO Instance => _instance ??= new CategoryDAO();

        private CategoryDAO() { }

        public List<Category> GetCategories()
        {
            return MyStoreContext.Categories.ToList();
        }

        public Category? GetCategoryById(int id)
        {
            return MyStoreContext.Categories.FirstOrDefault(c => c.CategoryId == id);
        }
    }
}
