using BusinessObjects;
using Repositories;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }

        public List<Category> GetCategories()
            => _categoryRepository.GetCategories();

        public Category? GetCategoryById(int id)
            => _categoryRepository.GetCategoryById(id);
    }
}
