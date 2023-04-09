using IcSMP_ApiApp.DTOs;
using IcSMP_ApiApp.DTOs.CreateUpdateObjects;
using Microsoft.AspNetCore.Mvc;

namespace IcSMP_ApiApp.Services
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task CreateCategoryAsync(Category category);
        public Task <bool>DeleteCategoryAsync(int id);
        public Task<CreateUpdateCategory> UpdateCategoryAsync(int id, CreateUpdateCategory category);
        public Task<CreateUpdateCategory> UpdatePartiallyCategoryAsync(int id, CreateUpdateCategory category);
    }
}
