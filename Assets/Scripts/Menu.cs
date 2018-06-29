using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

		var buttons = gameObject.GetComponentsInChildren<Button>();
		foreach (var btn in buttons)
		{
			btn.onClick.AddListener(delegate { Action(btn.name); });
		}
	}

	void Action(string type)
	{
		switch (type)
		{
			case "btnStory":
				SceneManager.LoadScene("scenes/Hallway", LoadSceneMode.Single);
				break;
			case "btnQuickPlay":
				SceneManager.LoadScene("scenes/GameStart", LoadSceneMode.Single);
				break;
			case "btnExit":
				SceneManager.LoadScene("scenes/Question", LoadSceneMode.Single);
				break;
		}
	}
}
