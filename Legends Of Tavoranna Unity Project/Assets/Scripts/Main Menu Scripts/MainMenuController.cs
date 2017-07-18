using UnityEngine;

public class MainMenuController : MonoBehaviour
{
	public GameObject darknessObject;

	public GameObject[] HideOnStart;
	public GameObject[] ShowOnStart;

	public PlayButton playbutton;

	public static GameObject darkness;

	private void Awake ()
	{

		darkness = darknessObject;
		darkness.SetActive(false);

		foreach (GameObject obj in HideOnStart)
		{

			obj.SetActive(false);
		}

		foreach (GameObject obj in ShowOnStart)
		{

			obj.SetActive(true);
		}
	}

	private void Update ()
	{

		if (Input.GetKeyDown(KeyCode.Escape))
		{

			foreach (GameObject obj in HideOnStart)
			{

				if (obj.activeSelf)
				{
					if (HideOnStart[3] == obj)
					{

						MainMenuController.darkness.SetActive(false);
					}

					obj.SetActive(false);
					break;
				}
			}
		}
	}

	public void PlayButtonPress ()
	{


	}
}