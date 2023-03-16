namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddUserDTO
    {
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
    }
}