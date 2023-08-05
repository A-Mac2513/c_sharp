using System.Linq;

namespace Quiz_App.Models
{
    public class Questions
    {
        private readonly Quiz_App_DB _context;

        public int id { get; set; }
        public string question { get; set; }

        public Questions()
        {
            _context = new Quiz_App_DB();
        }
        

        // Get all questions
        public string[] get_all_questions()
        {
            var questions = _context.Questions.ToArray();
            string[] all_questions = new string[questions.Length];
            for (int i = 0; i < questions.Length; i++)
            {
                all_questions[i] = questions[i].question;
            }
            return all_questions;
        }
    }
}
