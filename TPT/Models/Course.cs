using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TPT.Models
{
    public class Course
    {
        public Course()
    {
        this.Students = new HashSet<Student>();
        this.Instructors = new HashSet<Instructor>();
    }
        public int ID { get; set; }
        public string Name { get; set; }
        [Range(1, 4)]
        public int Credits { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}