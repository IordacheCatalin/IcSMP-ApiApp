using IcSMP_ApiApp.DTOs;

namespace IcSMP_ApiApp.Repository
{
    public interface ICategoriesRepository
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task CreateCategoryAsync(Category category);
        public Task<bool> DeleteCategoryAsync(int id);
    }
}
