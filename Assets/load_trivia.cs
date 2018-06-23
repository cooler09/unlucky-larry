﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_trivia : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene("scenes/Question", LoadSceneMode.Additive);
		}
	}
}
