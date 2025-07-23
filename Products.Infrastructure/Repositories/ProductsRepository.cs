using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using Products.Domain.Interfaces;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly ProductsDbContext _context;

    public ProductsRepository(ProductsDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Product>?> GetAllAsync()
    {
        return await Task.FromResult(_context.Products);
    }

    public async Task<Product?> GetByIDAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(_ => _.ID == id);
    }

    public async Task<int?> AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);

        int affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0 ? product.ID : null ;
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        // Validate if product exists
        Product? existingProduct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(_ => _.ID == product.ID);
        if (existingProduct == null)
        {
            return false; // Product not found
        }

        // Update properties
        _context.Entry(existingProduct).CurrentValues.SetValues(product);
        int affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0;
    }
    
    public async Task<bool> DeletAsync(int id)
    {
        Product? productToDelete = await _context.Products.FirstOrDefaultAsync(x => x.ID == id);
        if (productToDelete == null)
        {
            return false;
        }
        _context.Remove(productToDelete);
        int affectedRow = await _context.SaveChangesAsync();
        return affectedRow > 0;
    }
}
