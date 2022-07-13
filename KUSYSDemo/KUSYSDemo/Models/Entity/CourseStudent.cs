using System.ComponentModel.DataAnnotations;

namespace KUSYSDemo.Models.Entity
{
    public class CourseStudent
    {
        [Key]
        public int CourseStudentId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
