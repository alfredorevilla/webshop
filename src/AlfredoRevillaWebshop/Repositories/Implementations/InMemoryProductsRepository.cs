using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AlfredoRevillaWebshop.Models;
using AlfredoRevillaWebshop.Repositories.Models;

namespace AlfredoRevillaWebshop.Repositories.Implementations
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        private List<ProductRepositoryModel> _data;

        //  todo: logging
        public InMemoryProductsRepository()
        {
            _data = new List<ProductRepositoryModel>();
        }

        public string Name => "In Memory";

        public async Task<int> CreateAsync(CreateProductRepositoryModel model)
        {
            var id = _data.Any() ? _data.Max(o => o.Id) + 1 : 1;
            var toAdd = new ProductRepositoryModel
            {
                Id = id,
                MPN = model.MPN,
                Title = model.Title
            };
            _data.Add(toAdd);
            return await Task.FromResult(id);
        }

        public async Task<PagedResult<ProductRepositoryModel>> GetProductsAsync(GetProductsRepositoryModel model)
        {
            return await Task.FromResult(new PagedResult<ProductRepositoryModel>(_data.Skip(model.StartIndex).Take(model.MaxRecords), _data.Count));
        }
    }
}