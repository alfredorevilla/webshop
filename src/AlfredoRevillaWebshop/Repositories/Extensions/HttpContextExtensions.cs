using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AlfredoRevillaWebshop.Repositories.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetRequestedRepository(this HttpContext context)
        {
            return context.Request.Query["repository"].ToString();
        }
    }
}
