/***************************************************************************************
*    Title: <ASP.NET Core 3.1 - Hash and Verify Passwords with BCrypt>
*    Author: <JASON WATMORE'S BLOG>
*    Date Published: <16 June 2020>
*    Date Retreived: <25 May 2023>
*    Code version: <1.0.0>
*    Availability: <https://jasonwatmore.com/post/2020/07/16/aspnet-core-3-hash-and-verify-passwords-with-bcrypt>
*
***************************************************************************************/

/***************************************************************************************
*    Title: <Create Login Page in Asp.net (MVC 5 & SQL Server)>
*    Author: <C# Code Academy>
*    Date Published: <21 October 2018>
*    Date Retreived: <20 May 2023>
*    Code version: <1.0.0>
*    Availability: <https://www.youtube.com/watch?v=-860xZK5mRg&t=490s>
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
using BC = BCrypt.Net.BCrypt;
using System.Security.Principal;

namespace Jordan_Green._st10083222._PROG7311._POE._Part_2.Controllers
{
    public class EmployeeUsersController : Controller
    {
        private readonly PROG7311Context _context;

        public EmployeeUsersController(PROG7311Context context)
        {
            _context = context;
        }

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void connectString()
        {
            con.ConnectionString = "data source=DESKTOP-GUNQO71\\SQLEXPRESS;Initial Catalog=PROG7311;Integrated Security=True";
        }

        // GET: EmployeeUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email,Username,Password")] EmployeeUsers employeeUsers)
        {
            //string passwordHash = BCrypt.Net.BCrypt.HashPassword("Pa$$w0rd");

            if (ModelState.IsValid)
            {
                //// create new account object from model
                //var account = new Account(employeeUsers);

                //// hash password
                //account.PasswordHash = BC.HashPassword(employeeUsers.Password);

                // Using db context, adds user details to db
                _context.Add(employeeUsers);
                await _context.SaveChangesAsync();
                return Redirect("https://localhost:44337/FilterFarmerProducts/Home");
            }
            return View(employeeUsers);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: employeeUsers/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: employeeUsers/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(EmployeeUsers employeeUsers)
        {
            connectString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from EmployeeUsers where Username= '" + employeeUsers.Username +
                "' and Password='" + employeeUsers.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read()) // if statement: if it reads the db, draw the username and password from db and send the user to anoher page
            {
                con.Close();
                return Redirect("https://localhost:44337/FilterFarmerProducts/Home");
            }
            else
            {
                con.Close();
                return Redirect("https://localhost:44337/Home/FailedLogin");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
