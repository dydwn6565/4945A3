using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TPT.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeID { get; set; }

        public String EmployeeName { get; set; }

        //public String ServiceType { get; set; }

        

        public virtual Service Service { get; set; }
    }
}