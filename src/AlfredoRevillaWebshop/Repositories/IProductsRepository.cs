using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlfredoRevillaWebshop.Repositories.Models;

namespace AlfredoRevillaWebshop.Repositories
{
    public interface IProductsRepository
    {
        Task<int> CreateProduct(CreateProductRepositoryModel model);

        Task<IQueryable<ProductRepositoryModel>> QueryProducts();
    }
}
