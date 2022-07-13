using System.ComponentModel.DataAnnotations;

namespace KUSYSDemo.Models.Entity
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
