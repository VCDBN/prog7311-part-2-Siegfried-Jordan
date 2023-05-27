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
    public class EmployeeAddFarmerUsersController : Controller
    {
        private readonly PROG7311Context _context;

        public EmployeeAddFarmerUsersController(PROG7311Context context)
        {
            _context = context;
        }

        // GET: EmployeeAddFarmerUsers/Create User
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeAddFarmerUsers/Create Users
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email,Username,Password")] FarmerUsers farmerUsers)
        {
            if (ModelState.IsValid)
            {
                // Using db context, adds user details to db
                _context.Add(farmerUsers);
                await _context.SaveChangesAsync();
                return Redirect("https://localhost:44337/FilterFarmerProducts/Home");
            }
            return View(farmerUsers);
        }
    }
}
