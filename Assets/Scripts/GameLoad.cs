using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoad : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		WWW api = new WWW("http://localhost:54724/api/values");
		StartCoroutine(WaitForWWW(api));
	}
	IEnumerator WaitForWWW(WWW www)
	{
		yield return www;


		string txt = "";
		if (string.IsNullOrEmpty(www.error))
			txt = www.text;  //text of success
		else
			txt = www.error;  //error
		Debug.Log(txt);
	}
}
