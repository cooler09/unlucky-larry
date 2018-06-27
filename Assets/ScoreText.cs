using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
	{
		transform.GetComponent<Text>().text = "Score: " + Global.Score;
	}
}
