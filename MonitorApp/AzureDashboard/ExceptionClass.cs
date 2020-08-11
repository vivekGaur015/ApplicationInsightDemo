using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureDashboard
{
    public class ExceptionClass
    {
        public class Column
        {
            public string name { get; set; }
            public string type { get; set; }
        }

        public class Table
        {
            public string name { get; set; }
            public IList<Column> columns { get; set; }
            public IList<IList<object>> rows { get; set; }
        }

        public class APIData
        {
            public IList<Table> tables { get; set; }
        }

     
    }
}