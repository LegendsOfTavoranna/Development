using UnityEngine;
using UnityStandardAssets.Cameras;

public class PlayerController : MonoBehaviour
{

	private Camera main;
	public GameObject pivot, cameraTarget;

	public float minZoom, maxZoom, moveSpeed;
	public float minTargetHeight, maxTargetHeight;

	[HideInInspector]
	public int currentLayer;

	private float zoom;
	private float zoomDelta;
	private float xInputRaw;
	private float yInputRaw;

	private Vector3 oldPosition;
	private Rigidbody rigidBody;

	private void Start ()
	{

		main = Camera.main;
		rigidBody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate ()
	{

		xInputRaw = Input.GetAxisRaw("Horizontal");
		yInputRaw = Input.GetAxisRaw("Vertical");

		zoomDelta = Input.GetAxis("Mouse ScrollWheel");

		if (zoomDelta != 0)
		{

			AdjustZoom(-zoomDelta);
		}

		if (oldPosition != transform.localPosition)
		{
			
			AdjustRotation();
			AdjustPosition(xInputRaw, yInputRaw);
			oldPosition = transform.localPosition;

		}
		else if (xInputRaw != 0f || yInputRaw != 0f)
		{

			AdjustRotation();
			AdjustPosition(xInputRaw, yInputRaw);
			oldPosition = transform.localPosition;
		}

		if (Input.GetKeyDown (KeyCode.Space))
		{

			rigidBody.AddForce(Vector3.up * 300);
		}
	}

	private void AdjustZoom (float delta)
	{

		zoom = Mathf.Clamp01(zoom - delta);
		
        float distance = Mathf.Lerp(minZoom, maxZoom, zoom);

		var pos = new Vector3(0, 0, distance);

		pivot.transform.localPosition = pos;

		distance = Mathf.Lerp(maxTargetHeight, minTargetHeight, zoom);

		pos = new Vector3(0, distance, 0);
		cameraTarget.transform.localPosition = pos;
	}

	private void AdjustRotation ()
	{

		Vector3 pos = main.gameObject.transform.position;
		pos.y = transform.position.y;

		transform.LookAt(pos);
	}

	private void AdjustPosition (float xInput, float yInput)
	{

		Vector3 direction = transform.localRotation * new Vector3(-xInput, 0f, -yInput).normalized;
		float distance = Time.deltaTime * moveSpeed;

		Vector3 position = transform.localPosition;

		position += direction * distance;

		transform.localPosition = position;
	}
}