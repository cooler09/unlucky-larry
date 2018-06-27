
using System.Collections.Generic;

namespace DefaultNamespace
{
    public class TriviaInfo
    {
        public List<Question> Questions { get; set; }
        
        public TriviaInfo()
        {
            Questions = new List<Question>();
        }
    }
}