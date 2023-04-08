using IcSMP_ApiApp.DataContext;
using IcSMP_ApiApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace IcSMP_ApiApp.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IcSMPDataContext _context;
        public CategoriesRepository(IcSMPDataContext context)
        {
            _context = context;
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
            if(categoryToRemove == null)
            {
                return false;
            }
            _context.Category.Remove(categoryToRemove);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
