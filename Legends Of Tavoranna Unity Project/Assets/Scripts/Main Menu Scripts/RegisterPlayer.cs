using UnityEngine;
using UnityEngine.UI;
using GameSparks.Core;
using System;

public class RegisterPlayer : MonoBehaviour {

	public GameObject registerPanel, registerConfirmationPanel;
	public Text usernameOutput, emailOutput;

	[System.Serializable]
	public struct InputFieldDependencies
	{

		public Text Input;
		public Image InputErrorBox;
		public Image InputErrorHighlight;
		public Text InputErrorText;
	}

	public InputFieldDependencies username, emailAddress, password, confirmPassword;

	private void Awake ()
	{

		Initialize();
	}

	public void Initialize ()
	{

		username.Input.text = "";
		emailAddress.Input.text = "";
		password.Input.text = "";
		confirmPassword.Input.text = "";

		emailAddress.InputErrorBox.gameObject.SetActive(false);
		username.InputErrorBox.gameObject.SetActive(false);
		password.InputErrorBox.gameObject.SetActive(false);
		confirmPassword.InputErrorBox.gameObject.SetActive(false);

		emailAddress.InputErrorHighlight.gameObject.SetActive(false);
		username.InputErrorHighlight.gameObject.SetActive(false);
		password.InputErrorHighlight.gameObject.SetActive(false);
		confirmPassword.InputErrorHighlight.gameObject.SetActive(false);

		username.InputErrorText.text = "";
		emailAddress.InputErrorText.text = "";
		password.InputErrorText.text = "";
		confirmPassword.InputErrorText.text = "";
	}


	public void RegisterPlayerButton ()
	{
		Initialize();

		bool error = false;

		if (username.Input.text.Length < 6)
		{

			username.InputErrorBox.gameObject.SetActive(true);
			username.InputErrorHighlight.gameObject.SetActive(true);
			username.InputErrorText.text = "Username Must be Longer than Six Characters!";

			error = true;
		}
			
		if (password.Input.text.Length < 8)
		{

			password.InputErrorBox.gameObject.SetActive(true);
			password.InputErrorHighlight.gameObject.SetActive(true);
			password.InputErrorText.text = "Password Must be Longer than Eight Digits!";

			error = true;
		}
		if (confirmPassword.Input.text != password.Input.text)
		{

			password.InputErrorBox.gameObject.SetActive(true);
			password.InputErrorHighlight.gameObject.SetActive(true);
			password.InputErrorText.text = "Passwords do not Match!";

			confirmPassword.InputErrorBox.gameObject.SetActive(true);
			confirmPassword.InputErrorHighlight.gameObject.SetActive(true);
			confirmPassword.InputErrorText.text = "Passwords do not Match!";

			error = true;
		}

		if (error)
		{

			return;
		}

		var data = new GSRequestData()
			.AddString("email", emailAddress.Input.text);

		Debug.Log("Contacting...");

		new GameSparks.Api.Requests.RegistrationRequest()
			.SetUserName(username.Input.text)
			.SetDisplayName(username.Input.text)
			.SetPassword(password.Input.text)
			.SetScriptData(data)
			.Send((response) =>
			{

				if (!response.HasErrors)
				{

					Debug.Log("Player Registered \n User Name: " + response.DisplayName);

						var textObjects = registerPanel.GetComponentsInChildren<Text> (true);

						foreach (Text text in textObjects) {

							text.text = "";
						}

						registerPanel.SetActive(false);

						registerConfirmationPanel.SetActive(true);
						usernameOutput.text = username.Input.text;
						emailOutput.text = emailAddress.Input.text;
				}
				else
				{

					Debug.Log("Error Registering Player... \n " + response.Errors.JSON.ToString());

					if (response.Errors.JSON.Contains("\"USERNAME\":\"TAKEN\""))
					{

						username.InputErrorBox.gameObject.SetActive(true);
						username.InputErrorHighlight.gameObject.SetActive(true);
						username.InputErrorText.text = "Username Already Taken!";
					}
					if (response.Errors.JSON.Contains("\"error\":\"EMAIL TAKEN\""))
					{

						emailAddress.InputErrorBox.gameObject.SetActive(true);
						emailAddress.InputErrorHighlight.gameObject.SetActive(true);
						emailAddress.InputErrorText.text = "Email Address Already Taken!";
					}
				}
			});
		}
}