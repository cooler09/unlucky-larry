using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonclick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		var btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(delegate { Test(); });
	}
	
	// Update is called once per frame
	void Test () {
		Debug.Log("Clicked");
	}
}
