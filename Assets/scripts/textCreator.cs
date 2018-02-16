using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textCreator : MonoBehaviour {


	public Text tweetText;
	public Text screenName;
	public Text userName;

	void Start () {
//		this.GetComponentInParent<GameObject> ().SetActive (true);

	}
	
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
		tweet.InScreen = true;
		tweetText.text = tweet.tweetText;
		screenName.text = tweet.screenName;
		userName.text = tweet.name;
	}
}
