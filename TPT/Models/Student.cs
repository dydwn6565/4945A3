using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TPT.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Students")]
    public class Student : Person
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public int GPA { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}