using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOrigin : MonoBehaviour {
	public Transform target;
	private Transform myself;
	// Use this for initialization
	void Start () {
		myself = this.GetComponentInParent<RectTransform> ().transform;
		Vector3 relativePos = myself.position - target.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		myself.transform.rotation = rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
