using System;
using System.Linq;

namespace AlfredoRevillaWebshop.Repositories
{
    public interface IProductsRepositoryFactory
    {
        IProductsRepository Create(string repositoryName);

        string[] GetAvailableRepositoriesNames();
    }
}