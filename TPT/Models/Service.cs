using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TPT.Models
{
    public class Service
    {
        
        [ForeignKey("Employee")]
        public int ServiceID { get; set; }
        public string ServiceType { get; set; }
        public int CustomerID { get; set; }


       public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
    }
}