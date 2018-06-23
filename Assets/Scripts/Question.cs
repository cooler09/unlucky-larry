
using System.Collections.Generic;

namespace DefaultNamespace
{
    [System.Serializable]
    public class Question
    {
        public string title { get; set; }
        public object[] answers { get; set; }
    }
}