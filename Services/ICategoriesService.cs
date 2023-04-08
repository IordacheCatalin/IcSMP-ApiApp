using IcSMP_ApiApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace IcSMP_ApiApp.Services
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task CreateCategoryAsync(Category category);
        public Task <bool>DeleteCategoryAsync(int id);
    }
}
