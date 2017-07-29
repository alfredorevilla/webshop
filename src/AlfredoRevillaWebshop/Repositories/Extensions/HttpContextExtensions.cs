using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AlfredoRevillaWebshop.Repositories.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetRequestedRepository(this HttpContext context)
        {
            var repositoryName = context.Request.Query["repository"].ToString();
            if (string.IsNullOrEmpty(repositoryName))
            {
                return context.RequestServices.GetRequiredService<IProductsRepositoryFactory>().GetAvailableRepositoriesNames().First();
            }
            return repositoryName;
        }

        public static IEnumerable<string> GetAvailableRepositoriesNames(this HttpContext context)
        {
            return context.RequestServices.GetRequiredService<IProductsRepositoryFactory>().GetAvailableRepositoriesNames();
        }
    }
}