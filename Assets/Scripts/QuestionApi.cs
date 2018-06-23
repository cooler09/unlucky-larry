using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class QuestionApi :MonoBehaviour
    {
        private string _baseUrl;
        public QuestionApi(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        
//        IEnumerator WaitForWWW()
//        {
//            yield return _api;
//
//
//            string txt = "";
//            if (string.IsNullOrEmpty(_api.error))
//                txt = _api.text;  //text of success
//            else
//                txt = _api.error;  //error
//            Debug.Log(txt);
//        }
//
//        public List<Question> GetQuestions(int enemyId)
        //public int Register(string name)
//        {
//            StartCoroutine(WaitForWWW(api));
//            StartCoroutine(() => { yield return new WWW(_baseUrl); });
//        }
//
//        public GameState GetGameState(int id)
//        {
//            
//        }
        
    }

    public class GameState
    {
    }
}