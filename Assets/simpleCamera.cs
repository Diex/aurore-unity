using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(0, 0, Time.deltaTime * Input.GetAxis("Vertical") * 4.0f);		
	}
}
