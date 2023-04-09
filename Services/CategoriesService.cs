using IcSMP_ApiApp.DTOs;
using IcSMP_ApiApp.DTOs.CreateUpdateObjects;
using IcSMP_ApiApp.Repository;

namespace IcSMP_ApiApp.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _repository;
        public CategoriesService(ICategoriesRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _repository.GetCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _repository.GetCategoryByIdAsync(id);
        }

        public async Task CreateCategoryAsync(Category newCategory)
        {

            await _repository.CreateCategoryAsync(newCategory);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _repository.DeleteCategoryAsync(id);
        }

        public async Task<CreateUpdateCategory> UpdateCategoryAsync(int id, CreateUpdateCategory category)
        {
            return await _repository.UpdateCategoryAsync(id, category);
        }

        public async Task<CreateUpdateCategory> UpdatePartiallyCategoryAsync(int id, CreateUpdateCategory category)
        {
            return await _repository.UpdatePartiallyCategoryAsync(id, category);
        }
    }
}

