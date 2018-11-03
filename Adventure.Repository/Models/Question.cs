using System.ComponentModel.DataAnnotations;

namespace Adventure.Repository.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string AskQuestion { get; set; }
        public string Answer { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}