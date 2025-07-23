using Products.Domain.Entities;

namespace Products.Domain.Interfaces;

public interface IBrandsRepository
{
    public Task<IEnumerable<Brand>?> GetAllAsync();
    public Task<Brand?> GetByIDAsync(int id);
    public Task<int?> AddAsync(Brand brand);
    public Task<bool> UpdateAsync(Brand brand);
    public Task<bool> DeletAsync(int id);
}
