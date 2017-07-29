using AlfredoRevillaWebshop.Models;
using AlfredoRevillaWebshop.Repositories.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using AlfredoRevillaWebshop.Repositories.Implementations.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace AlfredoRevillaWebshop.Repositories.Implementations
{
    public class SqlServerDbContextProductsRepository : IProductsRepository
    {
        private SqlServerDbContext _dbContext;

        public SqlServerDbContextProductsRepository(string connectionString)
        {
            _dbContext = new SqlServerDbContext(connectionString);
        }

        public async Task<int> CreateAsync(CreateProductRepositoryModel model)
        {
            var added = _dbContext.Add(new ProductRepositoryModel
            {
                MPN = model.MPN,
                Price = model.Price,
                Title = model.Title
            });
            await this._dbContext.SaveChangesAsync();
            return added.Entity.Id;
        }

        public async Task<PagedResult<ProductRepositoryModel>> GetProductsAsync(GetProductsRepositoryModel model)
        {
            var totalRecords = this._dbContext.Products.Count();
            return await Task.FromResult(new PagedResult<ProductRepositoryModel>(this._dbContext.Products.Skip(model.StartIndex).Take(model.MaxRecords), totalRecords));
        }
    }
}