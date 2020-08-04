using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExceptionLogging;
using EmployeeApp.Models;

namespace EmployeeApp.Controllers
{
    public class HomeController : Controller
    {
        public static readonly List<Employee> Items = new List<Employee>();
      //  CloudRoleNameInitializer cloudRoleNameInitializer = new CloudRoleNameInitializer("Employee");
        LogException logException = new LogException("Employee Project");
        
        // GET: Home
        public ActionResult Index()
        {
            
            try
            {

                LogException.TrackInfo("Employee Project");
                LogException.SendMetrices("Employee Metric", 42.3);

                LogException.TrackViewPages("Employee List Page", Request.Url.AbsoluteUri);


                if (Items.Count==0)
                {
                    Items.Add(new Employee { ID = 1, CreatedDate = DateTime.Now, EmpCode = "101", Name = "Vivek" });
                    Items.Add(new Employee { ID = 2, CreatedDate = DateTime.Now, EmpCode = "102", Name = "Sumit" });
                    Items.Add(new Employee { ID = 3, CreatedDate = DateTime.Now, EmpCode = "103", Name = "Abhishek" });
                    Items.Add(new Employee { ID = 4, CreatedDate = DateTime.Now, EmpCode = "104", Name = "Tarun" });
                    Items.Add(new Employee { ID = 5, CreatedDate = DateTime.Now, EmpCode = "105", Name = "John" });
                }
                
                return View(Items.ToList());
            }
            catch (Exception ex)
            {
               LogException.TrackException(ex);
                return View("ErrorPage");
            }

         
        }

        public ActionResult ErrorCall()
        {

            try
            {
                throw new Exception("Custom Error Called in Employee Project");
            }
            catch (Exception ex)
            {
                LogException.TrackException(ex);

                return View("ErrorPage");
            }
        }

        public ActionResult ErrorPage()
        {

            return View();
        }
    }
}