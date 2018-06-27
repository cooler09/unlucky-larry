using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : MonoBehaviour {

    float moveSpeed= 1.0f;
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.RightArrow) && Global.CanMove)
        {
            transform.position = transform.position += transform.right * 6.0f * Time.deltaTime;
        }
    }
}
