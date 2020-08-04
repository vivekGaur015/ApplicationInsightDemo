using AzureDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureDashboard.Controllers
{
    public class DashboardController : Controller
    {


        // GET: Dashboard
        public ActionResult Index()
        {
            var ResultData = new ExceptionClass.Example(); 
            Designation role = Designation.Manager;
            if (role == Designation.Employee)
            {

                ResultData = CallAzureAPIs.CallExceptionTelemetry();
            }
            else if (role == Designation.Manager)
            {
                ResultData = CallAzureAPIs.GetTotalException();
            }

            ViewBag.RoleName = role; 

            return View(ResultData);
        }
    }
}