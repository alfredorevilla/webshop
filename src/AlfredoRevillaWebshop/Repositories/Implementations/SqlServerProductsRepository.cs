using AlfredoRevillaWebshop.Models;
using AlfredoRevillaWebshop.Repositories.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlfredoRevillaWebshop.Repositories.Implementations
{
    public class SqlServerProductsRepository : IProductsRepository
    {
        public string Name => throw new NotImplementedException();

        public Task<int> CreateAsync(CreateProductRepositoryModel model)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<ProductRepositoryModel>> GetProductsAsync(GetProductsRepositoryModel model)
        {
            return Task.FromResult(new PagedResult<ProductRepositoryModel>(Enumerable.Empty<ProductRepositoryModel>(), 0));
        }
    }
}