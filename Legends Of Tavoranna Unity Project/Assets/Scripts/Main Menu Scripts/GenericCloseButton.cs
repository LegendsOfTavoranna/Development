using UnityEngine;
using UnityEngine.UI;

// drop this on a close button, set the rectTransform to the parent object and mainMenuController to the MainMenuController script
public class GenericCloseButton : MonoBehaviour
{

	public MainMenuController mainMenuController;

	public RectTransform parent;

	private Button button;

	private void Start ()
	{

		button = GetComponent<Button>();

		button.onClick.AddListener(CloseButton);
	}

	public void CloseButton ()
	{
		
		mainMenuController.Escape();
	}
}