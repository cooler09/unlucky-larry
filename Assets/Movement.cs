using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
    float moveSpeed= 1.0f;
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + 1.0f, transform.position.y);
        }
    }
}
