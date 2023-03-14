using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string TestName { get; set; }
        public string Description { get; set; }
        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExpireOn { get; set; }
        [ForeignKey("Technology")]
        public int TechnologyId { get; set; }
        public User User { get; set; }
        public Technology Technology { get; set; }
    }
}