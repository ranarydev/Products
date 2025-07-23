using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using Products.Domain.Interfaces;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly ProductsDbContext _context;

    public CategoriesRepository(ProductsDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Category>?> GetAllAsync()
    {
        return await Task.FromResult(_context.Categories);
    }

    public async Task<Category?> GetByIDAsync(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(_ => _.ID == id);
    }

    public async Task<int?> AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);

        int affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0 ? category.ID : null;
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        // Validate if category exists
        Product? existingCategory = await _context.Products.AsNoTracking().FirstOrDefaultAsync(_ => _.ID == category.ID);
        if (existingCategory == null)
        {
            return false; // Category not found
        }

        // Update properties
        _context.Entry(existingCategory).CurrentValues.SetValues(category);
        int affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }

    public async Task<bool> DeletAsync(int id)
    {
        Category? categoryToDelete = await _context.Categories.FirstOrDefaultAsync(x => x.ID == id);
        if (categoryToDelete == null)
        {
            return false;
        }
        _context.Remove(categoryToDelete);
        int affectedRow = await _context.SaveChangesAsync();
        return affectedRow > 0;
    }
}
