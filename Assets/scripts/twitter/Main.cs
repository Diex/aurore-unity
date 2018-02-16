using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Main : MonoBehaviour {

	public GameObject textRender;
	public InputField hashtag;
	public CameraControl cam;

	private string tag = "#aurore";
	private ArrayList collectedTweets;


	// Use this for initialization
	void Start () {	
		var se = new InputField.SubmitEvent ();
		se.AddListener (setHashtag);
		hashtag.onEndEdit = se;
		hashtag.text = tag;
		collectedTweets = new ArrayList ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void setHashtag(string args0)
	{
		this.tag = args0;
		StartCoroutine(getTweets ());

	}
		
	IEnumerator getTweets()
	{
		Debug.Log ("getTweets(): " + tag);
		TwitterAPI.instance.SearchTwitter(tag, CollectTweets);
		yield return tag;
		Invoke ("getTweets", 10.0f);
	}

	void CollectTweets(List<TweetSearchTwitterData> tweetList) {
		Debug.Log ("found: " + tweetList.Count.ToString());
		foreach (TweetSearchTwitterData newt in tweetList) {
			if (!TweetExistsInCollection (newt)) {
				collectedTweets.Add (newt);
			}
		}

		ShowTweets ();
	}

	private bool TweetExistsInCollection(TweetSearchTwitterData newt)
	{
		foreach (TweetSearchTwitterData prevt in collectedTweets) {
			if (newt.tweetId == prevt.tweetId) {
				return true;
			} 
		}
		return false;
	}

	private GameObject lastTweet;

	private void ShowTweets()
	{
		foreach (TweetSearchTwitterData tweet in collectedTweets) {
			if (!tweet.InScreen) {				
				GameObject tc = Instantiate (textRender);
				tc.GetComponent<textCreator> ().onNewTex (tweet);
				lastTweet = tc;
				Invoke ("ShowTweets", 5.0f);
				Transform target = tc.transform.Find ("target");
				cam.moveTo (target);
				cam.lookAt (tc.transform);
				return;
			}
		}
	}

//	IEnumerator LoadData()
//	{
//		string directory = "file://" + Application.dataPath + "/../" + "settings.json";
//		WWW www = new WWW(directory);
//		yield return www;
//		LoadDataromServer( www.text);
//	}


}
