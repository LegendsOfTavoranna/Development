using UnityEngine;

public class MainMenuController : MonoBehaviour {

	public GameObject largeLogo;
	public PlayButton playbutton;

	private void Awake () {

		largeLogo.gameObject.SetActive(true);
	}
}