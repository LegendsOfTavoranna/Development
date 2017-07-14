using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour
{

	public Camera main;

	public float minZoom, maxZoom, moveSpeed;

	[HideInInspector]
	public int currentLayer;

	private float zoom;
	private float zoomDelta;
	private float xInput;

	private Vector3 oldPosition;
	private Rigidbody rigidBody;

	private void Start ()
	{

		rigidBody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate ()
	{

		xInput = Input.GetAxis("Horizontal");

		zoomDelta = Input.GetAxis("Mouse ScrollWheel");

		if (zoomDelta != 0)
		{

            AdjustZoom(zoomDelta);
		}

		if (oldPosition != transform.localPosition)
		{

			AdjustPosition(xInput);
			oldPosition = transform.localPosition;

		}
		else if (xInput != 0f)
		{

			AdjustPosition(xInput);
			oldPosition = transform.localPosition;
		}

		if (Input.GetKeyDown (KeyCode.Space))
		{


			rigidBody.AddForce(Vector3.up * 500);
		}
	}

	private void OnCollisionEnter (Collision collision) { 

//		if (collision.collider.tag == "Floor")
//		{
//
//
//		}
	}

	private void AdjustZoom (float delta)
	{

		zoom = Mathf.Clamp01(zoom - delta);
		
        float distance = Mathf.Lerp(minZoom, maxZoom, zoom);

		main.transform.localPosition = new Vector3(0, 0, -distance);
	}

	private void AdjustPosition (float xInput)
	{

		Vector3 direction = new Vector3(xInput, 0) * moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? 2 : 1);
		Vector3 position = transform.localPosition;

		position += direction;

		transform.localPosition = position;
	}
}