using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textCreator : MonoBehaviour {


	public Text text;

	// Use this for initialization
	void Start () {
//		this.GetComponentInParent<GameObject> ().SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake() {
		Vector3 pos = Random.insideUnitSphere;
		pos.x *= 4000;
		pos.y *= 2500;
		pos.z *= 2500;
		this.GetComponentInParent<RectTransform> ().transform.position = pos;
	}

	public void onNewTex(TweetSearchTwitterData tweet)
	{
		text.text = tweet.tweetText;

	}
}
