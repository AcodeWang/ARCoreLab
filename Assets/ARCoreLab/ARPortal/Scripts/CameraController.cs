using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") , 0, Input.GetAxis("Vertical")) * 0.1f);

        var rotation = 0;
        if(Input.GetKey(KeyCode.Q)){
            rotation -= 2;
        }
        else if(Input.GetKey(KeyCode.E))
        {
            rotation += 2;
        }

        transform.Rotate(0,rotation,0);
	}
}
