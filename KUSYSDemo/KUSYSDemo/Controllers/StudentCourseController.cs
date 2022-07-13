using KUSYSDemo.Models;
using KUSYSDemo.Models.Concrete;
using KUSYSDemo.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KUSYSDemo.Controllers
{
    public class StudentCourseController : Controller
    {
        [Authorize]
        public IActionResult List(Student student)
        {

            List<StudentCourses> studentCourses = ListStudentCourses(student.StudentId);

            ViewBag.Courses = FillCourses(studentCourses);
            ViewBag.StudentId = student.StudentId;

            return View(studentCourses);
        }
        [HttpPost]
        public IActionResult List(StudentCourses student)
        {

            using var c = new DataContext();
            Student s = c.Students.Find(student.StudentId);
            List<StudentCourses> studentCourses = ListStudentCourses(student.StudentId);
            ViewBag.Courses = FillCourses(studentCourses);
            ViewBag.StudentId = student.StudentId;
            if (student.CourseId != null)
            {
                Course co = c.Courses.Find(student.CourseId);
                CourseStudent st = new CourseStudent();
                st.Student = s;
                st.Course = co;
                c.CourseStudent.Add(st);
                c.SaveChanges();

            }

            return RedirectToAction("List", "StudentCourse", s);
        }

        List<SelectListItem> FillCourses(List<StudentCourses> studentCourses)
        {
            using var c = new DataContext();

            List<SelectListItem> newCourses = new List<SelectListItem>();

            foreach (Course item in c.Courses)
            {

                if (studentCourses.Where(p => p.CourseId == item.CourseId).ToList().Count == 0)
                {
                    SelectListItem courses = new SelectListItem
                    {
                        Text = item.CourseName,
                        Value = item.CourseId
                    };
                    newCourses.Add(courses);
                }

            }
            return newCourses;
        }


        [Authorize]
        public IActionResult Delete(StudentCourses studentCourses)
        {
            using var c = new DataContext();

            CourseStudent course = c.CourseStudent.Where(p => p.CourseStudentId == studentCourses.CourseStudentId).FirstOrDefault();
            Student student = c.Students.Find(studentCourses.StudentId);

            c.Remove(course);
            c.SaveChanges();

            return RedirectToAction("List", "StudentCourse", student);
        }

        List<StudentCourses> ListStudentCourses(int StudentId)
        {
            using var context = new DataContext();
            List<StudentCourses> courses = new List<StudentCourses>();

            return courses = (from c in context.Courses
                              join cs in context.CourseStudent
                              on c.CourseId equals cs.Course.CourseId
                              join st in context.Students
                              on cs.Student.StudentId equals st.StudentId
                              where cs.Student.StudentId == StudentId
                              select new StudentCourses
                              {
                                  CourseStudentId = cs.CourseStudentId,
                                  CourseName = c.CourseName,
                                  StudentName = (st.FirstName + " " + st.LastName),
                                  CourseId = c.CourseId,
                                  StudentId = cs.Student.StudentId
                              }).ToList();
        }

    }
}
