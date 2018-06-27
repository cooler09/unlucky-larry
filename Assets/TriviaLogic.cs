using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class TriviaLogic : MonoBehaviour
{
	private Transform panel;
	private Button button1;
	private Button button2;
	private Button button3;
	private Button button4;
	private Text Question;
	private bool buttonsRegisterd = false;
	private int currentQuestion = 0;

	// Use this for initialization
	void Start ()
	{
		panel = transform.GetChild(0);
		button1 = panel.GetChild(0).GetComponent<Button>();
		button2 = panel.GetChild(1).GetComponent<Button>();
		button3 = panel.GetChild(2).GetComponent<Button>();
		button4 = panel.GetChild(3).GetComponent<Button>();
		Question = panel.GetChild(4).GetComponent<Text>();

	}
	
	void Update ()
	{
		//fail proof incase game doesn't update fast enough
		if (!Global.showTrivia)
			return;
		
		if (currentQuestion >= 10)
		{
			Done();
			return;
		}
		if (!buttonsRegisterd)
		{
			Question.text = "Would you rather ride with me!";
			button1.onClick.AddListener(delegate { Answer(1); });
			button1.GetComponentsInChildren<Text>()[0].text = "What do you want?";
			button2.onClick.AddListener(delegate { Answer(2); });
			button2.GetComponentsInChildren<Text>()[0].text = "What do you want?";
			button3.onClick.AddListener(delegate { Answer(3); });
			button3.GetComponentsInChildren<Text>()[0].text = "What do you want?";
			button4.onClick.AddListener(delegate { Answer(4); });
			button4.GetComponentsInChildren<Text>()[0].text = "What do you want?";
		}
	}

	void Answer(int id)
	{
		currentQuestion++;
		Debug.Log(currentQuestion);
	}

	void Done()
	{
		Debug.Log("done");
		Global.CanMove = true;
		Global.showTrivia = false;
	}
}
