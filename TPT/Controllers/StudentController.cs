using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPT.Models;

namespace TPT.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Student/
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();
            foreach (var person in db.People.ToList())
            {
                if (person is Student)
                    students.Add(person as Student);
            }


            return View(students);
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = (Student) db.People.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Address,GPA")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = (Student) db.People.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        public ActionResult StudentCourses(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = (Student) db.People.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            //Course course = new Course();
            //course.Name = "COMP4900";
            //course.Credits = 4;
            //student.Courses.Add(course);
            ViewBag.ID = id;
            return View(student.Courses);
        }

        public ActionResult ListCourses(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ID = id;
            List<Course> courses = db.Courses.ToList();
            if (courses == null)
            {
                courses = new List<Course>();
            }
            return View(courses);
            //return View(db.Courses.ToList());
        }

        public ActionResult AddCourse(int? CourseID, int? StudentID)
        {
            if(CourseID == null || StudentID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(CourseID);
            Student student = db.Students.Find(StudentID);
            student.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("StudentCourses", new { id = StudentID });
        }

        public ActionResult RemoveCourse(int? CourseID, int? StudentID)
        {
            if (CourseID == null || StudentID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(CourseID);
            Student student = db.Students.Find(StudentID);
            student.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("StudentCourses", new { id = StudentID });
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Address,GPA")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = (Student) db.People.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student.Courses);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Student student = (Student) db.People.Find(id);
            db.People.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
