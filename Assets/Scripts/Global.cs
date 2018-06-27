using System.Collections.Generic;

namespace DefaultNamespace
{
    public static class Global
    {
        public static string CurrentEnemy = "emo";
        public static int UserId;
        public static string ServerBaseUrl = "http://localhost:5000/api/";
        public static Dictionary<string, TriviaInfo> TriviaInfo;
        public static bool CanMove = true;
        public static bool showTrivia = false;
        public static int Score = 0;

    }
}