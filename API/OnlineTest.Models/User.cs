using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string MobileNo { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(256)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}