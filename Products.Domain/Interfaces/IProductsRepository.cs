using Products.Domain.Entities;

namespace Products.Domain.Interfaces
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Product>?> GetAllAsync();
        public Task<Product?> GetByIDAsync(int id);
        public Task<int?> AddAsync(Product product);
        public Task<bool> UpdateAsync(Product product);
        public Task<bool> DeletAsync(int id);
    }
}
