using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using Products.Domain.Interfaces;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Repositories;

public class BrandsRepository : IBrandsRepository
{
    private readonly ProductsDbContext _context;

    public BrandsRepository(ProductsDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Brand>?> GetAllAsync()
    {
        return await Task.FromResult(_context.Brands);
    }

    public async Task<Brand?> GetByIDAsync(int id)
    {
        return await _context.Brands.FirstOrDefaultAsync(_ => _.ID == id);
    }

    public async Task<int?> AddAsync(Brand brand)
    {
        await _context.Brands.AddAsync(brand);

        int affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0 ? brand.ID : null;
    }

    public async Task<bool> UpdateAsync(Brand brand)
    {
        // Validate if brand exists
        Product? existingBrand = await _context.Products.AsNoTracking().FirstOrDefaultAsync(_ => _.ID == brand.ID);
        if (existingBrand == null)
        {
            return false; // Brand not found
        }

        // Update properties
        _context.Entry(existingBrand).CurrentValues.SetValues(brand);
        int affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }

    public async Task<bool> DeletAsync(int id)
    {
        Brand? brandToDelete = await _context.Brands.FirstOrDefaultAsync(x => x.ID == id);
        if (brandToDelete == null)
        {
            return false;
        }
        _context.Remove(brandToDelete);
        int affectedRow = await _context.SaveChangesAsync();
        return affectedRow > 0;
    }
}
