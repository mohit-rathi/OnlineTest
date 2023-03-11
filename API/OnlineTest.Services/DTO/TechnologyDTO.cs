namespace OnlineTest.Services.DTO
{
    public class TechnologyDTO
    {
        public int Id { get; set; }
        public string TechName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}