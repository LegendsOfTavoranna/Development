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
	private float yInput;

	private Vector3 oldPosition;

	private void LateUpdate ()
	{

		xInput = Input.GetAxis("Horizontal");
		yInput = Input.GetAxis("Vertical");

		zoomDelta = Input.GetAxis("Mouse ScrollWheel");

		if (zoomDelta != 0)
		{

			AdjustZoom(zoomDelta);
		}

		if (oldPosition != transform.localPosition)
		{

			AdjustPosition(xInput, yInput);
			oldPosition = transform.localPosition;

		}
		else if (xInput != 0f || yInput != 0f)
		{

			AdjustPosition(xInput, yInput);
			oldPosition = transform.localPosition;
		}
	}

	private void AdjustZoom (float delta)
	{

		zoom = Mathf.Clamp01(zoom - delta);

		float distance = Mathf.Lerp(minZoom, maxZoom, zoom);
		main.transform.localPosition = new Vector3(0, 0, -distance);
	}

	private void AdjustPosition (float xInput, float yInpput)
	{

		Vector3 direction = new Vector3(xInput, yInput) * moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? 2 : 1);
		Vector3 position = transform.localPosition;

		position += direction;

		transform.localPosition = position;
	}
}