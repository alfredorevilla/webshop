using System.Linq;
using System;
using AlfredoRevillaWebshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AlfredoRevillaWebshop.Services;
using AlfredoRevillaWebshop.Services.Models;

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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,MPN")] CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(new CreateProductServiceModel(model));
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAsync();
            return View(new PagedResult<ProductModel>(result.Select(o => new ProductModel(o)).ToArray(), result.TotalElements));
        }
    }
}