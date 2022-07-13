using System.ComponentModel.DataAnnotations;

namespace KUSYSDemo.Models.Entity
{
    public class Course
    {
        [Key]
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
