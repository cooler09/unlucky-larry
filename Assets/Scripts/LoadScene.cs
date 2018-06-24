using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {
    public GameObject Question;
    public GameObject Answer1;
    public GameObject Answer2;
    public GameObject Answer3;
    public GameObject Answer4;

    public GameObject LeftImage;
    public GameObject RightImage;

    public GameObject ImageLoader;

    private List<Question> _allQuestions;
    private Dictionary<int,Question> _currentQuestions = new Dictionary<int, Question>();
    private int currentQuestion;
    private bool gameOver = false;

    // Use this for initialization
    void Start () {
        //get questions
        StartCoroutine(GetCurrentQuestions());
        
        for (int i = 0; i < 10; i++)
        {
            var rng = Random.Range(0, _allQuestions.Count);
            var ques = _allQuestions[rng];
            _currentQuestions.Add(ques.id,ques);
        }
        

        Button btn;
        foreach (var q in _allQuestions)
        {
            for (int i = 0; i < q.answers.Count; i++)
            {
                var answer = q.answers[i];
                switch (i)
                {
                    case 0:
                        btn = Answer1.GetComponent<Button>();
                        btn.onClick.AddListener(delegate { Answer(answer.id); });
                        btn.GetComponentsInChildren<Text>()[0].text = answer.title;
                        break;
                    case 1:
                        btn = Answer2.GetComponent<Button>();
                        btn.onClick.AddListener(delegate { Answer(answer.id); });
                        btn.GetComponentsInChildren<Text>()[0].text = answer.title;
                        break;
                    case 2:
                        btn = Answer3.GetComponent<Button>();
                        btn.onClick.AddListener(delegate { Answer(answer.id); });
                        btn.GetComponentsInChildren<Text>()[0].text = answer.title;
                        break;
                    case 3:
                        btn = Answer4.GetComponent<Button>();
                        btn.onClick.AddListener(delegate { Answer(answer.id); });
                        btn.GetComponentsInChildren<Text>()[0].text = answer.title;
                        break;
                }
            }
        }

        btn = Answer2.GetComponent<Button>();
        btn.onClick.AddListener(delegate { Answer(2); });
        btn.GetComponentsInChildren<Text>()[0].text = "School Bus";

        btn = Answer3.GetComponent<Button>();
        btn.onClick.AddListener(delegate { Answer(3); });
        btn.GetComponentsInChildren<Text>()[0].text = "Snow Shoe";

        btn = Answer4.GetComponent<Button>();
        btn.onClick.AddListener(delegate { Answer(4); });
        btn.GetComponentsInChildren<Text>()[0].text = "Kitten";

        Question.GetComponent<Text>().text = "What is the biggest?";

        var images = ImageLoader.GetComponent<ImageLoader>();
        
        LeftImage.GetComponent<Image>().sprite = images.Larry;
        switch (Global.CurrentEnemy)
        {
                case "jocks":
                    RightImage.GetComponent<Image>().sprite = images.Jocks;
                    break;
                case "emo":
                    
                    RightImage.GetComponent<Image>().sprite = images.Emo;
                    break;
                default:
                    RightImage.GetComponent<Image>().sprite = images.Jocks;
                    break;
        }
    }

    void Update()
    {
        if (gameOver)
        {
            //post api question data
            //play clip
            Destroy(gameObject);
        }
    }
    IEnumerator  GetCurrentQuestions()
    {
        var group = Global.CurrentEnemy;
        var api = new WWW(Global.ServerBaseUrl + "QuestionData?group="+group);
        yield return api;
        if (string.IsNullOrEmpty(api.error))
        {
            _allQuestions = JsonConvert.DeserializeObject<List<Question>>(api.text);
        }
        else
            Debug.Log(api.error);
        

    }
    
    void Answer(int answerId)
    {
        gameOver = true;
    }
    

}
