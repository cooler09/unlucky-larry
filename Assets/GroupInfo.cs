using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class GroupInfo : MonoBehaviour
{
	private Text GroupTitle;
	// Use this for initialization
	void Start ()
	{
		GroupTitle = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (Global.CurrentEnemy)
		{
				case "emo":
					GroupTitle.text = "The Emo Kids";
					break;
				case "jock":
					GroupTitle.text = "The Jocks";
					break;
			case "nerd":
				GroupTitle.text = "The Nerds";
				break;
			case "hipster":
				GroupTitle.text = "The Hipsters";
				break;
			case "popular-girl":
				GroupTitle.text = "The Popular Girls";
				break;
		}
	}
}
