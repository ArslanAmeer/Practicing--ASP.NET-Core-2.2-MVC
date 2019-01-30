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

        // GET: Edit Action Method for Product Type

        public IActionResult Edit(int id)
        {
            using (_db)
            {
                var productType = _db.ProductTypes.Find(id);
                if (productType == null)
                {
                    return NotFound();
                }
                return View(productType);
            }
        }

        // Post: Edit Action Method To Update Product Type
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductType productType)
        {
            if (id != productType.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(productType);
            }
            using (_db)
            {
                _db.ProductTypes.Update(productType);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // GET: Detail Action Method for Product Type

        public IActionResult Details(int id)
        {
            using (_db)
            {
                var productType = _db.ProductTypes.Find(id);
                if (productType == null)
                {
                    return NotFound();
                }
                return View(productType);
            }
        }

        // GET: Delete Action Method for Product Type

        public IActionResult Delete(int id)
        {
            using (_db)
            {
                var productType = _db.ProductTypes.Find(id);
                if (productType == null)
                {
                    return NotFound();
                }
                return View(productType);
            }
        }

        // Post: Edit Action Method To Update Product Type
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (_db)
            {
                _db.ProductTypes.Remove(await _db.ProductTypes.FindAsync(id));
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}