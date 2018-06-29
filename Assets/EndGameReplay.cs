using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameReplay : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		gameObject.GetComponent<Button>().onClick.AddListener(delegate { Reload(); });
	}
	
	// Update is called once per frame
	void Reload ()
	{
		Global.CanMove = true;
		Global.CurrentEnemy = "emo";
		Global.showTrivia = false;
		Global.Score = 0;
		SceneManager.LoadScene("scenes/Hallway", LoadSceneMode.Single);
	}
}
