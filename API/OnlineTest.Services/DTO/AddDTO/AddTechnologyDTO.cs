namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddTechnologyDTO
    {
        public string TechName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}