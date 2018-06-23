using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
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

    private List<Question> _currentQuestions;

    // Use this for initialization
    void Start () {
        //get questions
        StartCoroutine(GetCurrentQuestions());
        

        Button btn = Answer1.GetComponent<Button>();
        btn.onClick.AddListener(delegate { Answer(1); });
        btn.GetComponentsInChildren<Text>()[0].text = "Orange";

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
        RightImage.GetComponent<Image>().sprite = images.Jocks;
    }

    IEnumerator  GetCurrentQuestions()
    {
        var group = Global.CurrentEnemy;
        var api = new WWW(Global.ServerBaseUrl + "QuestionData?group="+group);
        yield return api;

//        Debug.Log(
//            JsonConvert.DeserializeObject<List<Question>>(
//                "[{'title':'In what sport is a panty pass?','answers':[{'id':1,'title':'Lacrosse','questionId':1,'question':null},{'id':2,'title':'Curling','questionId':1,'question':null},{'id':3,'title':'Roller Derby','questionId':1,'question':null},{'id':4,'title':'Horse Racing','questionId':1,'question':null}]}]"));
        if (string.IsNullOrEmpty(api.error))
        {
            
        }
        else
            Debug.Log(api.error);
        

    }
    
    void Answer(int answerId)
    {
        Debug.Log("clicked" + answerId);
        Destroy(gameObject);
        
    }
    public Transform FindObjectwithTag(string tag)
    {
        return GetChildObject(transform, tag);
    }
 
    public Transform GetChildObject(Transform parent, string tag)
    {
        if (parent.CompareTag(tag))
        {
            return parent;
        }
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            return GetChildObject(child, tag);

        }
        return null;
    }
    

}
