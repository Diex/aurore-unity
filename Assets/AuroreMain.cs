using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroreMain : MonoBehaviour {

    //public ArrayList collectedTweets;
    public GameObject tweetprefab;
    public CameraControl cam;

	// Use this for initialization
	void Start () {
        EventsManager.OnNewTweets += ShowTweets;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void ShowTweets(ArrayList collectedTweets)
    {
        foreach (TweetSearchTwitterData tweet in collectedTweets)
        {
            if (!tweet.InScreen)
            {
                GameObject tweetRenderer = Instantiate(tweetprefab);
                TextCreator textCreator = tweetRenderer.GetComponent<TextCreator>();
               
                Vector3 pos = Random.insideUnitSphere;
                tweetRenderer.transform.position = pos;

                tweet.InScreen = true;

                textCreator.onNewTex(tweet);

                //Transform target = tweetRenderer.transform.Find("target");
                //cam.moveTo(target);
                //cam.lookAt(tweetRenderer.transform);
                //return;
            }
        }
    }

}
