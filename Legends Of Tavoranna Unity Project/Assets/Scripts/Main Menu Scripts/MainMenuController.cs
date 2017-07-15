using UnityEngine;

public class MainMenuController : MonoBehaviour {

	public LargeLogo largeLogo;
	public PlayButton playbutton;

	private void Awake () {

		largeLogo.gameObject.SetActive(true);
	}
}