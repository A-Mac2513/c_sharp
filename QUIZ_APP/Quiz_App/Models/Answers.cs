using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_App.Models
{
    public class Answers
    {
        private readonly Quiz_App_DB _context;
        public int id { get; set; }
        public string answer { get; set; }
        public Questions q_ { get; set; }
        /*public int q_id { get; set; }*/
        public bool is_correct { get; set; }

        public Answers()
        {
            _context = new Quiz_App_DB();
        }

        // Get all answers
     /*   public Answers[] get_all_answers()
        {
            var answers = _context.Answers.ToArray();
            return answers;
        }*/

        public string[] get_all_answers()
        {
            var answers = _context.Answers.ToArray();
            string[] all_answers = new string[answers.Length];
            for (int i = 0; i < answers.Length; i++)
            {
                all_answers[i] = answers[i].answer;
            }
            return all_answers;
        }

    }
}
