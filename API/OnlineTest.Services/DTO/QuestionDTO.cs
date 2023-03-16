﻿namespace OnlineTest.Services.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public string Que { get; set; }
        public int Type { get; set; }
        public int Weightage { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public int TestId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}