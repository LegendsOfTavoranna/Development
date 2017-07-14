using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Generic quit game button
public class QuitButton : MonoBehaviour {

	public RectTransform quitMenu;

	public Button quitButton;

	private Button button;

	private void Start ()
	{

		button = GetComponent<Button>();

		button.onClick.AddListener(QuitWindow);
		quitButton.onClick.AddListener(Quit);
	}

	private void QuitWindow ()
	{

		if (quitMenu.gameObject.activeSelf)
		{

			quitMenu.gameObject.SetActive(false);
		}
		else
		{

			quitMenu.gameObject.SetActive(true);
		}
	}

	private void Quit ()
	{

		Application.Quit();
	}
}