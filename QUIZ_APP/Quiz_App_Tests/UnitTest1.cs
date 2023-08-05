namespace Quiz_App_Tests
{
    public class Tests
    {
        private String[] questions;
        private String[] answers; 
        private Questions model_questions;
        private Answers model_answers;

        [SetUp]
        public void Setup()
        {
            model_questions = new Questions();     
            model_answers = new Answers();

        }

        [Test]
        public void test_it_has_questions()
        {
            // Get the questions from the model get function
            String[] questions = model_questions.get_all_questions();

            //Check if the questions array is empty
            Assert.IsNotEmpty(questions);           
        }

        [Test]
        public void test_it_has_answers()
        {
            // Get the answers from the model get function
            String[] answers = model_answers.get_all_answers();

            //Check if the answers array is empty
            Assert.IsNotEmpty(answers);
        }
    }
}