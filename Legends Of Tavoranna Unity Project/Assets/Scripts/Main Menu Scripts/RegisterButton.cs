using UnityEngine;

public class RegisterButton : MonoBehaviour
{
	
	public GameObject registerPanel;

	public void RegisterButtonPress ()
	{

		if (!registerPanel.activeSelf)
		{

			registerPanel.SetActive(true);
			registerPanel.GetComponentInChildren<RegisterPlayer>().Initialize();
		}
	}
}