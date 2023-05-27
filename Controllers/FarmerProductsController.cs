using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jordan_Green._st10083222._PROG7311._POE._Part_2.Models;

namespace Jordan_Green._st10083222._PROG7311._POE._Part_2.Controllers
{
    public class FarmerProductsController : Controller
    {
        private readonly PROG7311Context _context;

        public FarmerProductsController(PROG7311Context context)
        {
            _context = context;
        }

        // GET: FarmerProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.FarmerProducts.ToListAsync());
        }

        // GET: FarmerProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FarmerProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,TypeOfProduct,ProductName")] FarmerProducts farmerProducts)
        {
            if (ModelState.IsValid)
            {
                // Using db context, adds user details to db
                _context.Add(farmerProducts);
                await _context.SaveChangesAsync();
                return Redirect("https://localhost:44337/FarmerProducts/Create");
            }
            return View(farmerProducts);
        }
    }
}
