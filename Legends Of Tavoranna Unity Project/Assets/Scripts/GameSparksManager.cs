using UnityEngine;
using System;

/// <summary>
/// Game Sparks Manage Singleton
/// </summary>
public class GameSparksManager : MonoBehaviour
{
	/// <summary>
	/// Static Instance
	/// </summary>
	private static GameSparksManager instance = null;

	private void Awake ()
	{

		if (instance == null) // check to see if the instance has a refrence
		{

			instance = this; // if not, give it a refrence to this class...
			DontDestroyOnLoad(this.gameObject); // and make this object persistant as we load new scenes
		}
		else // if we already have a refrence then remove the extra manager from the scene
		{

			Destroy(this.gameObject);
		}
	}
}