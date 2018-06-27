using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	private int currentQuestionCount = 0;
	private Question currentQuestion;
	private List<Question> questions;
	private bool loadNextQuestion = false;
	private DateTime answerTimer;

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

	void Update()
	{
		//fail proof incase game doesn't update fast enough
		if (!Global.showTrivia)
			return;

		if ((questions == null || questions.Count == 0) && !string.IsNullOrEmpty(Global.CurrentEnemy))
			LoadQuestions();

		if (currentQuestionCount >= 10)
		{
			Done();
			return;
		}

		if (loadNextQuestion && DateTime.Now > answerTimer.AddSeconds(2.0))
		{
			Debug.Log("load next");
			LoadNextQuestion();
		}
}

	void SetButtonColor(Button button, Color color)
	{
		ColorBlock cb = button.colors;
		cb.normalColor = color;
		cb.highlightedColor = color;
		button.colors = cb;
	}

	void Answer(int id)
	{
		
		//clear old listeners
		button1.onClick.RemoveAllListeners();
		button2.onClick.RemoveAllListeners();
		button3.onClick.RemoveAllListeners();
		button4.onClick.RemoveAllListeners();
		int correctAnswerId = currentQuestion.correctAnswerId;
		Debug.Log("Guess: "+id + " COrrect: " + correctAnswerId);
		
		for (int i = 0; i < 4; i++)
		{
			var a = currentQuestion.answers[i].id;
			Debug.Log(i+" "+a);
			Color color = (correctAnswerId == a) ? Color.green : Color.red;
			switch (i)
			{
				case 0:
					SetButtonColor(button1,color);
					break;
				case 1:
					SetButtonColor(button2,color);
					break;
				case 2:
					SetButtonColor(button3,color);
					break;
				case 3:
					SetButtonColor(button4,color);
					break;
			}
		}

		if (correctAnswerId == id)
		{
			Debug.Log("correct");
			Global.Score++;
		}


		currentQuestionCount++;
		if (currentQuestionCount < 10)
			loadNextQuestion = true;
		answerTimer = DateTime.Now;
	}

	void LoadQuestions()
	{
		questions = Global.TriviaInfo[Global.CurrentEnemy].Questions;
		loadNextQuestion = true;
	}
	void LoadNextQuestion()
	{
		
		currentQuestion = questions[currentQuestionCount];
		
		var ans1 = currentQuestion.answers[0];
		var ans2 = currentQuestion.answers[1];
		var ans3 = currentQuestion.answers[2];
		var ans4 = currentQuestion.answers[3];
		
		//listeners
		button1.onClick.AddListener(delegate { Answer(ans1.id); });
		button2.onClick.AddListener(delegate { Answer(ans2.id); });
		button3.onClick.AddListener(delegate { Answer(ans3.id); });
		button4.onClick.AddListener(delegate { Answer(ans4.id); });
		
		Question.text = currentQuestion.title;
		button1.GetComponentsInChildren<Text>()[0].text = ans1.title;
		button2.GetComponentsInChildren<Text>()[0].text = ans2.title;
		button3.GetComponentsInChildren<Text>()[0].text = ans3.title;
		button4.GetComponentsInChildren<Text>()[0].text = ans4.title;
		
		SetButtonColor(button1,Color.white);
		SetButtonColor(button2,Color.white);
		SetButtonColor(button3,Color.white);
		SetButtonColor(button4,Color.white);
		loadNextQuestion = false;
	}
	

	void Done()
	{
		questions = null;
		Global.CanMove = true;
		Global.showTrivia = false;
	}
}
