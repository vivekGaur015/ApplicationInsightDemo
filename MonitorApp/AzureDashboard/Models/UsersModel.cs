using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AzureDashboard.Models
{
    public class UsersModel
    {
        [Key]
        public Int32 EmpID { get; set; }
        public Designation Designation { get; set; }
        public string Name { get; set; }
    }

    public enum Designation
    {
        Employee = 0,
        Manager = 1,
        AssistantManager = 2,
        CEO = 3
    }
}