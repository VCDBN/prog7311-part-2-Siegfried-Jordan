/***************************************************************************************
*    Title: <Tutorial: Add sorting, filtering, and paging with the Entity Framework in an ASP.NET MVC application>
*    Author: <Microsoft>
*    Date Published: <16 June 2020>
*    Date Retreived: <25 May 2023>
*    Code version: <1.0.0>
*    Availability: <https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application>
*
***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jordan_Green._st10083222._PROG7311._POE._Part_2.Models;
using Microsoft.Data.SqlClient;

namespace Jordan_Green._st10083222._PROG7311._POE._Part_2.Controllers
{
    public class FilterFarmerProductsController : Controller
    {
        private readonly PROG7311Context _context;

        public FilterFarmerProductsController(PROG7311Context context)
        {
            _context = context;
        }

        // GET: FilterFarmerProducts
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            var FarmerProducts = from s in _context.FarmerProducts
                                 select s;

            if (!String.IsNullOrEmpty(searchString)) // search bar to find uersname
            {
                FarmerProducts = FarmerProducts.Where(s => s.Username.Contains(searchString));

            }
            // filter TypeOfProduct in descending order
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            switch (sortOrder)
            {
                case "name_desc":
                    FarmerProducts = FarmerProducts.OrderByDescending(s => s.TypeOfProduct);
                    break;
                default:
                    FarmerProducts = FarmerProducts.OrderBy(s => s.ProductName);
                    break;
            }
            return View(FarmerProducts.ToList());
        }

        // GET: FilterFarmerProducts
        public async Task<IActionResult> Home(string sortOrder, string searchString)
        {
            return View();
        }

    }
}
