using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureDashboard
{
    public class LogsViewModel
    {
        public ExceptionClass.APIData Exception { get; set; }

        public ExceptionClass.APIData Traces { get; set; }

    }
}