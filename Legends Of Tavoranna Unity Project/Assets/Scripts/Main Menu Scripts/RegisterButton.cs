using UnityEngine;

public class RegisterButton : MonoBehaviour
{

	public RegisterPlayer registerPlayerScript;

	public GameObject registerPanel;

	public void RegisterButtonPress ()
	{

		if (!registerPanel.activeSelf)
		{

			registerPanel.SetActive(true);
		}
	}
}