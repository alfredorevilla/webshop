using System.Linq;
using System;
using System.Threading.Tasks;
using AlfredoRevillaWebshop.Models;
using AlfredoRevillaWebshop.Services.Models;

using System;

namespace AlfredoRevillaWebshop.Services
{
    public class ProductService
    {
        public async Task<int> CreateAsync(CreateProductServiceModel productServiceModel)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductServiceModel>> GetAsync()
        {
            return await Task.FromResult(new PagedResult<ProductServiceModel>(Enumerable.Empty<ProductServiceModel>().ToArray(), 0));
        }
    }
}