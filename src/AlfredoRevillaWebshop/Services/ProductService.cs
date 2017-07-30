using System.Linq;
using System;
using System.Threading.Tasks;
using AlfredoRevillaWebshop.Models;
using AlfredoRevillaWebshop.Repositories;
using AlfredoRevillaWebshop.Repositories.Models;
using AlfredoRevillaWebshop.Services.Models;

namespace AlfredoRevillaWebshop.Services
{
    public class ProductService
    {
        private IProductsRepositoryFactory _factory;
        private IProductsRepository _repository;

        public ProductService(IProductsRepositoryFactory factory, IProductsRepository repository)
        {
            this._factory = factory;
            this._repository = repository;
        }

        public async Task<int> CreateAsync(CreateProductServiceModel model)
        {
            return await _repository.CreateAsync(new CreateProductRepositoryModel
            {
                MPN = model.MPN,
                Title = model.Title,
                Price = model.Price
            });
        }

        public async Task<PagedResult<ProductServiceModel>> GetAsync(GetProductsServiceModel model)
        {
            var result = await _repository.GetProductsAsync(new GetProductsRepositoryModel
            {
                StartIndex = model.StartIndex,
                MaxRecords = model.MaxRecords
            });
            return new PagedResult<ProductServiceModel>(result.Select(o => new ProductServiceModel(o)), result.TotalElements);
        }
    }
}