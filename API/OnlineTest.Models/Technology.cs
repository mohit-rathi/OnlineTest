using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Models
{
    public class Technology
    {
        [Key]
        public int Id { get; set; }
        public string TechName { get; set; }
        [ForeignKey("UserCreatedBy")]
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [ForeignKey("UserModifiedBy")]
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public User UserCreatedBy { get; set; }
        public User UserModifiedBy { get; set; }
    }
}