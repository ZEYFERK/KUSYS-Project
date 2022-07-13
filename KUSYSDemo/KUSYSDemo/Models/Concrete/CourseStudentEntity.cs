using KUSYSDemo.Models.Abstract;
using KUSYSDemo.Models.Entity;

namespace KUSYSDemo.Models.Concrete
{
    public class CourseStudentEntity : ICourseStudentEntity
    {
        public void Delete(CourseStudent t)
        {
            using var c = new DataContext();
            c.Remove(t);
            c.SaveChanges();
        }

        public List<CourseStudent> GetAll()
        {
            using var c = new DataContext();
            return c.CourseStudent.ToList();
        }

        public CourseStudent GetById(int Id)
        {
            using var c = new DataContext();
            return c.CourseStudent.Where(p => p.Student.StudentId == Id).FirstOrDefault();
        }

        public void Insert(CourseStudent t)
        {
            using var c = new DataContext();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(CourseStudent t)
        {
            using var c = new DataContext();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
