using System.Collections;
using System.Collections.Generic;
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

    // Use this for initialization
    void Start () {
        WWW api = new WWW("http://localhost:54724/api/values");
        StartCoroutine(WaitForWWW(api));

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
    void Click(int answerId)
    {
        Debug.Log("clicked" + answerId);
    }
    void Answer(int answerId)
    {
        //send answer to game server
    }
    IEnumerator WaitForWWW(WWW www)
    {
        yield return www;


        string txt = "";
        if (string.IsNullOrEmpty(www.error))
            txt = www.text;  //text of success
        else
            txt = www.error;  //error
        Debug.Log(txt);
    }

}
