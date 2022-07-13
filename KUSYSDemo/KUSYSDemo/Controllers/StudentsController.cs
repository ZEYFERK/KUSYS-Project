using KUSYSDemo.Models;
using KUSYSDemo.Models.Concrete;
using KUSYSDemo.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KUSYSDemo.Controllers
{
    public class StudentsController : Controller
    {
        DataContext context = new DataContext();
        [Authorize]
        public IActionResult List()
        {
            using var c = new DataContext();
            List<Student> students = new List<Student>();
            var roleId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            var loginName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            var loginPassword = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (roleId == "1")
                students = c.Students.ToList();
            else
                students = c.Students.Where(p => p.LoginUserName == loginName && p.LoginPassword == loginPassword).ToList();
            return View(students);
        }

      
        public IActionResult Detail(int Id)
        {
            using var c = new DataContext();
            Student s = new Student();
            s = c.Students.Find(Id);
            return PartialView("Detail", s);
        }

        [HttpGet, Authorize(Roles = "1")]
        public IActionResult Create()
        {
            Student student = new Student();

            return View(student);
        }

        [HttpPost, Authorize(Roles = "1")]
        public IActionResult Create(Student student)
        {
            if (student != null)
            {
                StudentEntity s = new StudentEntity();
                s.Insert(student);

            }
            return RedirectToAction("List");
        }

    }
}
