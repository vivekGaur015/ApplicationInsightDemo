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
            var ResultData = new LogsViewModel(); 
            Designation role = Designation.Manager;
            if (role == Designation.Employee)
            {

                ResultData.Exception = CallAzureAPIs.CallExceptionTelemetry();
                ResultData.Traces = CallAzureAPIs.GetTraces();

            }
            else if (role == Designation.Manager)
            {
                ResultData.Exception = CallAzureAPIs.GetTotalException();
                ResultData.Traces = CallAzureAPIs.GetTotalTraces();
            }

            ViewBag.RoleName = role; 

            return View(ResultData);
        }
    }
}