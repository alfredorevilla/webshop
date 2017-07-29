using System;
using System.Collections.Generic;
using System.Linq;

namespace AlfredoRevillaWebshop.Repositories.Implementations
{
    public class DefaultProductsRepositoryFactory : IProductsRepositoryFactory
    {
        private static DefaultProductsRepositoryFactory _instance;

        private Dictionary<string, Func<IProductsRepository>> _lambdas = new Dictionary<string, Func<IProductsRepository>>();

        static DefaultProductsRepositoryFactory()
        {
            _instance = new DefaultProductsRepositoryFactory();
        }

        DefaultProductsRepositoryFactory()
        {
            _lambdas.Add("In Memory", () => new InMemoryProductsRepository());
            _lambdas.Add("SQL Server", () => new SqlServerProductsRepository());
        }

        public static IProductsRepositoryFactory Instance
        {
            get
            {
                return _instance;
            }
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