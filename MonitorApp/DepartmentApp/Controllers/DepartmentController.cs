using DepartmentApp.Models;
using ExceptionLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepartmentApp.Controllers
{
    public class DepartmentController : Controller
    {
        public static readonly List<Department> Items = new List<Department>();
        CloudRoleNameInitializer cloudRoleNameInitializer = new CloudRoleNameInitializer("Department");
        LogException logException = new LogException("Department Project");
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                LogException.TrackInfo("Department Project");

                if (Items.Count == 0)
                {
                    Items.Add(new Department { DepartId = 1, DepartCode = "D01", DepartName="Accounts" });
                    Items.Add(new Department { DepartId = 2, DepartCode = "D02", DepartName = "Research & Development" });
                    Items.Add(new Department { DepartId = 3, DepartCode = "D03", DepartName = "Management" });
                    Items.Add(new Department { DepartId = 4, DepartCode = "D04", DepartName = "HR" });
                    Items.Add(new Department { DepartId = 5, DepartCode = "D05", DepartName = "Admin" });
                }

                return View(Items.ToList());
            }
            catch (Exception ex)
            {
               // LogException.TrackException(ex);
                throw;
            }
          
        }
    }
}