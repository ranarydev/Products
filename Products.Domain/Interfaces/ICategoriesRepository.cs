using Products.Domain.Entities;

namespace Products.Domain.Interfaces;

public interface ICategoriesRepository
{
    public Task<IEnumerable<Category>?> GetAllAsync();
    public Task<Category?> GetByIDAsync(int id);
    public Task<int?> AddAsync(Category category);
    public Task<bool> UpdateAsync(Category category);
    public Task<bool> DeletAsync(int id);

}
