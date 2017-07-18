using UnityEngine;
using UnityEngine.UI;

public class LogInPlayer : MonoBehaviour
{

	public Text userNameInput, passwordInput;

	public void AuthorizePlayerButton ()
	{

		Debug.Log("Authorizing Player...");

		new GameSparks.Api.Requests.AuthenticationRequest()
			.SetUserName(userNameInput.text)
			.SetPassword(passwordInput.text)
			.Send((response) =>
			{

				

				if (!response.HasErrors)
				{

					Debug.Log("Player Authenticated... \n User Name: " + response.DisplayName);
				}
				else
				{
					
					Debug.Log("Error Authentacing Player... \n " + response.Errors.JSON.ToString());
				}
			});
	}
}