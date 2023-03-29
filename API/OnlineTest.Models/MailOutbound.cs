using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Models
{
    public class MailOutbound
    {
        [Key]
        public int Id { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        [ForeignKey("TestLink")]
        public int TestLinkId { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public TestLink TestLink { get; set; }
    }
}