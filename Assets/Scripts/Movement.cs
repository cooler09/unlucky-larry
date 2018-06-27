using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	    StartCoroutine(Register());
	    
	}
    IEnumerator  Register()
    {
        var form = new WWWForm();
 
 
        var www = new WWW(Global.ServerBaseUrl + "User");
 
        yield return www;

 
        if(string.IsNullOrEmpty(www.error) ) {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text );
            Global.UserId = int.Parse(www.text);
        }
        

    }
    float moveSpeed= 1.0f;
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.RightArrow) && Global.CanMove)
        {
            transform.position = transform.position += transform.right * 6.0f * Time.deltaTime;
        }
    }
}
