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
		
		StartCoroutine(GetGameStateData());
		//get data from api and put in static global class	
		Global.TriviaInfo = new Dictionary<string, TriviaInfo>();
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
			var data = JsonConvert.DeserializeObject<GameStateData>(api.text);
			
			Global.UserId = data.UserId;
			Debug.Log(data.UserId);
		}
		else
			Debug.Log(api.error);
	}
	
	
}
