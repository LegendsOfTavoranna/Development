using UnityEngine;

public class PlayButton : MonoBehaviour
{
	
	public GameObject logInPanel;

	private bool isLoggedIn = false;

	public void PlayButtonPress ()
	{

		if (isLoggedIn)
		{

			FindObjectOfType<MainMenuController>().PlayButtonPress();
		}
		else
		{

			logInPanel.SetActive(true);
			MainMenuController.darkness.SetActive(true);
		}
	}
}