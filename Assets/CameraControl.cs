using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	[SerializeField]
	public float speed = 30;


	private Transform cam;
	private Transform target;
	private Transform lookTarget;

	private float startTime = 0;
	private float journeyLength = 0;

	// Use this for initialization
	void Start () {
		cam = GetComponentInParent<Camera> ().gameObject.transform;
		cam.position = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		if (this.target) {
			Vector3 newpos = Vector3.Lerp (cam.position, target.position, fracJourney);
			cam.position = newpos;

			var targetRotation = Quaternion.LookRotation(lookTarget.position - cam.position);

			// Smoothly rotate towards the target point.
			cam.rotation = Quaternion.Slerp(cam.rotation, targetRotation, fracJourney);
		}
	}


	public void moveTo(Transform target)
	{
		startTime = Time.time;
		this.target = target;
		journeyLength = Vector3.Distance(cam.position, target.position);
	}

	public void lookAt(Transform target)
	{
		this.lookTarget = target;

	}
}
