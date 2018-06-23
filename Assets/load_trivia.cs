using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_trivia : MonoBehaviour
{

	public string EnemyName;
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			Global.CurrentEnemy = EnemyName;
			
			SceneManager.LoadScene("scenes/Question", LoadSceneMode.Additive);
		}
	}
}
