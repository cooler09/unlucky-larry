using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class EnemyData : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		gameObject.GetComponent<Text>().text = Global.CurrentEnemy;
	}
}
