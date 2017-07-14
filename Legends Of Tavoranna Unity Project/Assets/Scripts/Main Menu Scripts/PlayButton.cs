using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour {
	
	public GameObject logInPanel;

	private bool isLoggedIn = false;

	public void Start () {

		logInPanel.SetActive(false);
	}

	public void PlayButtonPress ()
	{

		if (isLoggedIn)
		{

			//start game stuff
		}
		else
		{

			logInPanel.SetActive(true);
		}
	}
}