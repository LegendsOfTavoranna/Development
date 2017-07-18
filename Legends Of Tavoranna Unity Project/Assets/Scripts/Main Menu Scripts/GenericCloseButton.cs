using UnityEngine;
using UnityEngine.UI;

// drop this on a close button, set the rectTransform to the parent object and let it do the rest of the work
public class GenericCloseButton : MonoBehaviour
{

	public RectTransform parent;

	private Button button;

	private void Start ()
	{

		button = GetComponent<Button>();

		button.onClick.AddListener(CloseButton);
	}

	public void CloseButton ()
	{
		
		parent.gameObject.SetActive(false);
		MainMenuController.darkness.SetActive(false);
	}
}