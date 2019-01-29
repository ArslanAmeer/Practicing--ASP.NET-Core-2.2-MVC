using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraniteHouse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            using (_db)
            {
                return View(_db.ProductTypes.ToList());
            }
        }

        // GET: Create Action Method for Product Type

        public IActionResult CreateProductType()
        {
            return View();
        }

        // Post: Create Action Method To save Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductType(ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return View(productType);
            }
            using (_db)
            {
                _db.ProductTypes.Add(productType);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}