using System.Collections;
using UnityEngine;
using System;

public class TweetSearchTwitterData {
	public bool InScreen = false;

	public string tweetText = "";
	public string screenName = "";
	public string name = "";
	public string profileImageUrl = "";
	public Int64 retweetCount = 0;
	public Int64 tweetId = 0;

	public override string ToString(){
		return screenName + " posted: \"" + tweetText + "\" and retweeted " + retweetCount.ToString() + " times. Profile image URL: " +  profileImageUrl;
	}
}