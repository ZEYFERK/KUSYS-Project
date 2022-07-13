using KUSYSDemo.Models.Abstract;
using KUSYSDemo.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace KUSYSDemo.Models.Concrete
{
    public class StudentEntity : IStudentEntity
    {
        public void Delete(Student t)
        {
            using var c = new DataContext();
            c.Remove(t);
            c.SaveChanges();
        }

        public List<Student> GetAll()
        {
            using var c = new DataContext();
            return c.Students.ToList();
        }

        public Student GetById(int Id)
        {
            using var c = new DataContext();
            return c.Students.Where(p => p.StudentId == Id).FirstOrDefault();
        }

        public void Insert(Student t)
        {
            using var c = new DataContext();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(Student t)
        {
            using var c = new DataContext();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
