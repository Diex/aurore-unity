using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Main : MonoBehaviour {

	public class tweetComparer : IComparer  {
		// Calls CaseInsensitiveComparer.Compare with the parameters reversed.
		int IComparer.Compare( System.Object x, System.Object y )  {
			TweetSearchTwitterData a = (TweetSearchTwitterData)x;
			TweetSearchTwitterData b = (TweetSearchTwitterData)y;

			if (a.tweetId > b.tweetId)
				return 1;
			if (a.tweetId < b.tweetId)
				return -1;
			else
				return 0;
		}

		public static tweetComparer instance()
		{
			return new tweetComparer ();
		}

	}




	public GameObject textRender;
	public InputField hashtag;

	private string tag = "#aurore";
	private ArrayList tweets;


	// Use this for initialization
	void Start () {	
		var se = new InputField.SubmitEvent ();
		se.AddListener (setHashtag);
		hashtag.onEndEdit = se;

		tweets = new ArrayList ();
		w = File.AppendText(Application.persistentDataPath +"log3.txt");
//		getTweets ();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")) {
			Debug.Log ("logging");
			w = new StreamWriter(Application.dataPath + "Account.txt");
			foreach (TweetSearchTwitterData twitterData in tweets) {
				Main.Log (twitterData.tweetId.ToString(), w);
			}

			w.Close ();
		}
	}

	public void setHashtag(string args0)
	{
		this.tag = args0;
		getTweets ();
	}


	StreamWriter w;

	public static void Log(string logMessage, TextWriter w)
	{
		w.WriteLine (logMessage);
	}


	void getTweets()
	{
		Debug.Log ("getTweets(): " + tag);
		TwitterAPI.instance.SearchTwitter(tag, SearchTweetsResultsCallBack);
		Invoke ("getTweets", 10.0f);

	}

	void SearchTweetsResultsCallBack(List<TweetSearchTwitterData> tweetList) {
		Debug.Log ("found: " + tweetList.Count.ToString());

		foreach (TweetSearchTwitterData newt in tweetList) {
			if (!tweetExists (newt)) {
				tweets.Add (newt);
//				Log (newt.tweetId.ToString(), w);
			}

		}

//			GameObject tc = Instantiate (textRender);
//			tc.GetComponent<textCreator>().onNewTex (twitterData);
			
		Debug.Log ("current tweets: " + tweets.Count.ToString ());

	}

	private bool tweetExists(TweetSearchTwitterData newt)
	{
		foreach (TweetSearchTwitterData prevt in tweets) {
			if (newt.tweetId == prevt.tweetId) {
				return true;
			} 
		}

		return false;
	}

	void FindTrendsByLocatiobResultsCallBack(List<TrendByLocationTwitterData> trendList) {
		foreach(TrendByLocationTwitterData twitterData in trendList) {
//			Debug.Log("Trend: " + twitterData.ToString());
		}
	}

	public void onEvent(Event e){
		Debug.Log (e);
	}

	protected void Application_End()
	{
//		w.Dispose();

	}



}
