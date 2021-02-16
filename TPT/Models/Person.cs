using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace TPT.Models
{
    public class Person
    {
        public int ID { get; set; }
        //[Key]
        //[Column(Order=1)]
        public string Name { get; set; }
        //[Column(Order=2)]
        public string Address { get; set; }
    }
}