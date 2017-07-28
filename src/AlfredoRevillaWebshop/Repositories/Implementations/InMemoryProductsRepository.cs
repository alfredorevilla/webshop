﻿using System.Linq;
using System;
using AlfredoRevillaWebshop.Models;
using AlfredoRevillaWebshop.Repositories.Models;
using System.Collections.Concurrent;

using System.Linq;

using System.Threading.Tasks;

namespace AlfredoRevillaWebshop.Repositories.Implementations
{
    //  todo: logging
    public class InMemoryProductsRepository : IProductsRepository
    {
        private static readonly ConcurrentQueue<ProductRepositoryModel> _data;

        static InMemoryProductsRepository()
        {
            _data = new ConcurrentQueue<ProductRepositoryModel>();
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
            _data.Enqueue(toAdd);
            return await Task.FromResult(id);
        }

        public async Task<PagedResult<ProductRepositoryModel>> GetProductsAsync(GetProductsRepositoryModel model)
        {
            return await Task.FromResult(new PagedResult<ProductRepositoryModel>(_data.Skip(model.StartIndex).Take(model.MaxRecords).Select(o => new ProductRepositoryModel { Id = o.Id, MPN = o.MPN, Price = o.Price, Title = o.Title }), _data.Count));
        }
    }
}