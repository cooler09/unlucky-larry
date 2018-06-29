using System.Collections.Generic;

namespace DefaultNamespace
{
    public class GameStateData
    {
        public int UserId { get; set; }
        public Dictionary<string,TriviaInfo> questions { get; set; }
    }
}