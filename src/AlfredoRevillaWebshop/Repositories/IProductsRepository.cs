using System;
using System.Linq;
using System.Threading.Tasks;
using AlfredoRevillaWebshop.Models;
using AlfredoRevillaWebshop.Repositories.Models;

namespace AlfredoRevillaWebshop.Repositories
{
    public interface IProductsRepository
    {
        Task<int> CreateAsync(CreateProductRepositoryModel model);

        Task<PagedResult<ProductRepositoryModel>> GetProductsAsync(GetProductsRepositoryModel model);
    }
}