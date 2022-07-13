using System.ComponentModel.DataAnnotations;

namespace KUSYSDemo.Models.Entity
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı adını giriniz!")]
        public string LoginUserName { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifreyi giriniz!")]
        public string LoginPassword { get; set; }
        public int RoleId { get; set; }
        public virtual List<CourseStudent> Courses { get; set; }

    }
}
