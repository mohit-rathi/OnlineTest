using System.ComponentModel.DataAnnotations;

namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddAnswerDTO
    {
        [Required(ErrorMessage = "Answer is required")]
        public string Ans { get; set; }
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}