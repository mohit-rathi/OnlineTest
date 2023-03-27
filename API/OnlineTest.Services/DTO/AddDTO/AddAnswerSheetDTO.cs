namespace OnlineTest.Services.DTO.AddDTO
{
    public class AddAnswerSheetDTO
    {
        public Guid Token { get; set; }
        public List<Question> Questions { get; set; }
        public class Question
        {
            public int QuestionId { get; set; }
            public List<int> Answers { get; set; }
        }
        public DateTime CreatedOn { get; set; }
    }
}