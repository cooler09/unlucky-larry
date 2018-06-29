using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Newtonsoft.Json;
using UnityEngine;

public class GameState : MonoBehaviour
{

	public GameObject TriviaCanvas;
	// Use this for initialization
	void Start () {

		//get data from api and put in static global class	
		StartCoroutine(GetGameStateData());
		//LoadFakeData();
	}

	void LoadFakeData()
	{
		Global.TriviaInfo = new Dictionary<string, TriviaInfo>
		{
			{
				GroupName.Emo, new TriviaInfo
				{
					Questions = GetQuestions()
				}
			},
			{
				GroupName.Jock, new TriviaInfo
				{
					Questions = GetQuestions()
				}
			},
			
			{
				GroupName.Hipster, new TriviaInfo
				{
					Questions = GetQuestions()
				}
			},
			
			{
				GroupName.PopularGirl, new TriviaInfo
				{
					Questions = GetQuestions()
				}
			},
			{
				GroupName.Nerd, new TriviaInfo
				{
					Questions = GetQuestions()
				}
			}
		};

	}

	List<Question> GetQuestions()
	{
		var questions = new List<Question>();
		
		for (int i = 0; i < 10; i++)
		{
			questions.Add(new Question
			{
				correctAnswerId = Random.Range(10,14),
				answers = GetAnswers(),
				id = i,
				title = "Q"+i
			});
		}

		return questions;
	}

	List<Answer> GetAnswers()
	{
		return new List<Answer>
		{
			new Answer
			{
				id = 10,
				title = "A1"
			},
			new Answer
			{
				id = 11,
				title = "A2"
			},
			new Answer
			{
				id = 12,
				title = "A3"
			},
			new Answer
			{
				id = 13,
				title = "A4"
			}
		};
	}

	void Update()
	{
		TriviaCanvas.SetActive(Global.showTrivia);
	}

	IEnumerator GetGameStateData()
	{
		var api = new WWW(Global.ServerBaseUrl + "GameState");
		yield return api;
		if (string.IsNullOrEmpty(api.error))
		{
			Global.TriviaInfo= JsonConvert.DeserializeObject<GameStateData>(api.text).questions;
			
		}
		else
			Debug.Log(api.error);
	}
	
	
}
