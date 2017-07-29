using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace AlfredoRevillaWebshop.Repositories.Implementations
{
    public class DefaultProductsRepositoryFactory : IProductsRepositoryFactory
    {
        private Dictionary<string, Func<IProductsRepository>> _lambdas = new Dictionary<string, Func<IProductsRepository>>();

        public DefaultProductsRepositoryFactory(IConfiguration configuration)
        {
            _lambdas.Add("In Memory", () => new InMemoryProductsRepository());
            _lambdas.Add("SQL Server", () => new SqlServerDbContextProductsRepository(configuration.GetConnectionString("SqlServerDbContextProductsRepository").Replace("%CONTENTROOTPATH%", Directory.GetCurrentDirectory())));
        }

        public IProductsRepository Create(string repositoryName)
        {
            if (string.IsNullOrWhiteSpace(repositoryName))
            {
                throw new ArgumentException(nameof(repositoryName));
            }
            return _lambdas[repositoryName]();
        }

        public string[] GetAvailableRepositoriesNames()
        {
            return this._lambdas.Keys.ToArray();
        }
    }
}