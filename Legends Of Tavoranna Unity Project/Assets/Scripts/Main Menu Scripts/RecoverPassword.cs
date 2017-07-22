using UnityEngine;
using UnityEngine.UI;

public class RecoverPassword : MonoBehaviour
{
	
	public GameObject tokenRequestPanel, tokenInputPanel;

	public Text recoveryTokenInput;
	public Text emailInput, passwordInput, confirmPasswordInput;
	public Text recoveryTokenErrorText, emailErrorText, passwordErrorText, confirmPasswordErrorText;
	public GameObject recoveryTokenErrorHighlight, emailErrorHighlight, passwordErrorHighlight, confirmPasswordErrorHighlight;

	public void ForgotPasswordButton ()
	{

		recoveryTokenInput.text = "";
		emailInput.text = "";
		passwordInput.text = "";
		confirmPasswordInput.text = "";

		MainMenuController.darkness.SetActive(true);
		this.gameObject.SetActive(true);
		tokenRequestPanel.SetActive(true);
		tokenInputPanel.SetActive(false);

		recoveryTokenErrorHighlight.SetActive(false);
		emailErrorHighlight.SetActive(false);
		passwordErrorHighlight.SetActive(false);
		confirmPasswordErrorHighlight.SetActive(false);

		Initialize();
	}

	private void Initialize ()
	{

		emailErrorText.text = "";
		passwordErrorText.text = "";
		confirmPasswordErrorText.text = "";
	}

	public void SendRecoveryTokenRequest ()
	{

		Initialize();

		Debug.Log("Sending Recovery Token Request...");

		var data = new GameSparks.Core.GSRequestData()
			.AddString("email", emailInput.text)
			.AddString("action", "passwordRecoveryRequest");

		new GameSparks.Api.Requests.AuthenticationRequest()
			.SetUserName("")
			.SetPassword("")
			.SetScriptData(data)
			.Send((response) =>
			{

					if (response.Errors.GetString("action") == "complete")
					{

						Debug.Log (string.Format("Request Token Sent To Email : {0}", emailInput.text));
						tokenInputPanel.SetActive(true);
						tokenRequestPanel.SetActive(false);
					}
					else
					{

						Debug.Log ("Error Requesting Token... \n " + response.Errors.JSON.ToString());
						emailErrorText.text = "Invalid E-Mail. Please Try Again.";
						emailErrorHighlight.SetActive(true);
					}
			});
	}

	public void ConfirmRecoveryToken ()
	{
		bool error = false;
		Initialize();

		if (passwordInput.text.Length < 8)
		{

			passwordErrorHighlight.SetActive(true);
			passwordErrorText.text = "Password Must be Longer than Eight Digits!";
		}

		if (passwordInput.text != confirmPasswordInput.text)
		{

			confirmPasswordErrorText.text = "Passwords do not Match!";
			passwordErrorText.text = "Passwords do not Match!";
			confirmPasswordErrorHighlight.SetActive(true);
			passwordErrorHighlight.SetActive(true);
			error = true;
		}

		if (error)
		{

			return;
		}

		var data = new GameSparks.Core.GSRequestData()
			.AddString("token", recoveryTokenInput.text)
			.AddString("password", passwordInput.text)
			.AddString("action", "resetPassword");

		Debug.Log("Contacting...");

		new GameSparks.Api.Requests.AuthenticationRequest()
			.SetUserName("")
			.SetPassword("")
			.SetScriptData(data)
			.Send((response) =>
			{

					if (response.Errors.GetString("action") == "complete")
					{

						Debug.Log ("Password change Successful!");
						this.gameObject.SetActive(false);
					}
					else
					{

						Debug.Log ("Error... \n " + response.Errors.JSON.ToString());

						recoveryTokenErrorText.text = "Recovery Token Incorrect.";
						recoveryTokenErrorHighlight.SetActive(true);
					}
			});
	}
}