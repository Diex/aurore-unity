using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCreator : MonoBehaviour {


	public Text tweetText;
	public Text screenName;
	public Text userName;

	void Start () {

	}
	
	void Update () {
		
	}

	//void Awake() {
		//Vector3 pos = Random.insideUnitSphere;
		//this.GetComponentInParent<RectTransform> ().transform.position = pos;
	//}

	public void onNewTex(TweetSearchTwitterData tweet)
	{
		tweet.InScreen = true;
		tweetText.text = tweet.tweetText;
		screenName.text = tweet.name;
		userName.text = "@"+tweet.screenName;
	}
}
