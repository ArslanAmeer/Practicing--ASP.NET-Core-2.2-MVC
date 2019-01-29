using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
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
    }
}