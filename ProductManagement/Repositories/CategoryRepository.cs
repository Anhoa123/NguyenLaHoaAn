using BusinessObjects;
using DataAccessObjects;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetCategories()
            => CategoryDAO.Instance.GetCategories();

        public Category? GetCategoryById(int id)
            => CategoryDAO.Instance.GetCategoryById(id);
    }
}
