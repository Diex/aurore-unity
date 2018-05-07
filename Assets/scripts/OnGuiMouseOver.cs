using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnGuiMouseOver : MonoBehaviour {
	public CanvasGroup cg;
	// Use this for initialization
	void Start () {
		
//		cg = GetComponent<CanvasGroup> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PointerEnter()
	{
		//If your mouse hovers over the GameObject with the script attached, output this message
		Debug.Log("Mouse is over GameObject.");
		cg.alpha = 1;
	}

	public void PointerExit()
	{
		//If your mouse hovers over the GameObject with the script attached, output this message
		Debug.Log("Mouse is out GameObject.");
		cg.alpha = 0;
	}
}
