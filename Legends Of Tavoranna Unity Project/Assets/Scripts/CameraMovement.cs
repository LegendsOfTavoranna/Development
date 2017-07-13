using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
	//This script gets attached to the camera gameobject.
	
	public GameObject player; //The player gameobject in the scene gets assinged here

	void Update ()
	{
		this.transform.position = new Vector3 (player.transform.position.x, 1.16f, -10);
	}
}