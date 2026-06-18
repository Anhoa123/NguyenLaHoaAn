using BusinessObjects;

namespace Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category? GetCategoryById(int id);
    }
}
