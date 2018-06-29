using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextEnd : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		var text = gameObject.GetComponent<Text>().text = Global.Score.ToString();
	}
}
