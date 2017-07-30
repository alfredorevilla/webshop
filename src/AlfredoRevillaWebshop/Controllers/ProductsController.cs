using System.Linq;
using System;
using AlfredoRevillaWebshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AlfredoRevillaWebshop.Services;
using AlfredoRevillaWebshop.Services.Models;
using AlfredoRevillaWebshop.Repositories.Extensions;

namespace AlfredoRevillaWebshop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,MPN,Price")] CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(new CreateProductServiceModel(model));
                return RedirectToAction(nameof(Index), new { repository = this.HttpContext.GetRequestedRepository() });
            }
            return View(model);
        }

        // GET: Products
        public async Task<IActionResult> Index(int page = 0, int pageSize = 3)
        {
            var result = await _service.GetAsync(new GetProductsServiceModel
            {
                StartIndex = page > 0 ? page * pageSize : 0,
                MaxRecords = pageSize
            });
            return View(new PaginatedList<ProductModel>(result.Select(o => new ProductModel(o)), result.TotalElements, page, pageSize));
        }
    }
}