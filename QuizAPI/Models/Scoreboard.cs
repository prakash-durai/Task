using Microsoft.EntityFrameworkCore;

namespace QuizAPI.Models
{
    [Keyless]
    public class Scoreboard
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? AttendedQuiz { get; set; }
        public string? Score { get; set; }
        public string? MaximumScore { get; set; }
    }
}