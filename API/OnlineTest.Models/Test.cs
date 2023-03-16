﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string TestName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpireOn { get; set; }
        public int TechnologyId { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        [ForeignKey("Technology")]
        public Technology Technology { get; set; }
    }
}