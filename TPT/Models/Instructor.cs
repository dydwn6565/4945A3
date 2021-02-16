using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TPT.Models
{
     [System.ComponentModel.DataAnnotations.Schema.Table("Instructors")]
    public class Instructor : Person
    {
          public Instructor()
        {
            this.Courses = new HashSet<Course>();
        }
        public int salary { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}