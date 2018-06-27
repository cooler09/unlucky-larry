using Boo.Lang;

namespace DefaultNamespace
{
    public class TriviaInfo
    {
        public List<Question> Questions { get; set; }
        public List<int> QuestionAnswerIds { get; set; }
        
        public TriviaInfo()
        {
            Questions = new List<Question>();
            QuestionAnswerIds = new List<int>();
        }
    }
}