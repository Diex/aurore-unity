using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TweetsMan : MonoBehaviour
{

    [SerializeField]
    [Range(0.0f, 10.0f)]
    public float timeout = 2.0f; 

    private string hashtag = "#apple";
    private ArrayList collectedTweets;
    private ArrayList readedTweets;

	// Use this for initialization
	void Start()
	{
        collectedTweets = new ArrayList();
        readedTweets = new ArrayList();
        getTweets();
        //StartCoroutine(getTweets());
	}

	// Update is called once per frame
	void Update()
	{
			
	}

    void getTweets()
    {
        Debug.Log("getTweets(): " + hashtag);
        TwitterAPI.instance.SearchTwitter(hashtag, CollectTweets);


    }

    void CollectTweets(List<TweetSearchTwitterData> tweetList)
    {
        Debug.Log("found: " + tweetList.Count.ToString());

        foreach (TweetSearchTwitterData newt in tweetList)
        {

            collectedTweets.Add(newt);
        }

        Invoke("getTweets", timeout);
        EventsManager.OnNewTweets(collectedTweets);
        //StartCoroutine(getTweets());

    }
}
