
using System.Collections.Generic;

namespace DefaultNamespace
{
    [System.Serializable]
    public class Question
    {
        public int id { get; set; }
        public string title { get; set; }
        public int correctAnswerId { get; set; }
        public List<Answer> answers { get; set; }
    }
}