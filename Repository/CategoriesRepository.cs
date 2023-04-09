using AutoMapper;
using IcSMP_ApiApp.DataContext;
using IcSMP_ApiApp.DTOs;
using IcSMP_ApiApp.DTOs.CreateUpdateObjects;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace IcSMP_ApiApp.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IcSMPDataContext _context;
        private readonly IMapper _mapper;
        public CategoriesRepository(IcSMPDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get all announcements
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Category.ToListAsync();
        }
        //Get by id announcements

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Category.SingleOrDefaultAsync(x => x.Id == id);
        }

        //Create 
        public async Task CreateCategoryAsync(Category category)
        {
            category.Id = new();
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
        }
        //Delete

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var categoryToRemove = await GetCategoryByIdAsync(id);
            if (categoryToRemove == null)
            {
                return false;
            }
            _context.Category.Remove(categoryToRemove);
            await _context.SaveChangesAsync();
            return true;
        }

        //Update
        public async Task<CreateUpdateCategory> UpdateCategoryAsync(int id, CreateUpdateCategory category)
        {
            if (!await ExistCategoryAsync(id))
            {
                return null;
            }

            //categoryIsDb.Id = id;
            //categoryIsDb.Name = category.Name;
            //categoryIsDb.Description = category.Description;

            var updatedCategory = _mapper.Map<Category>(category);
            updatedCategory.Id = id;
            _context.Category.Update(updatedCategory);
            await _context.SaveChangesAsync();
            return category;
        }
        private async Task<bool> ExistCategoryAsync(int id)
        {
            return await _context.Category.CountAsync(x => x.Id == id) > 0;
        }
        //Patch
        public async Task<CreateUpdateCategory> UpdatePartiallyCategoryAsync(int id, CreateUpdateCategory category)
        {
            var categoryFromDb = await GetCategoryByIdAsync(id);

            if (categoryFromDb == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(category.Name) && category.Name != categoryFromDb.Name)
            {
                categoryFromDb.Name = category.Name;
            }
            if (!string.IsNullOrEmpty(category.Description) && category.Description != categoryFromDb.Description)
            {
                categoryFromDb.Description = category.Description;
            }
            _context.Category.Update(categoryFromDb);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}


