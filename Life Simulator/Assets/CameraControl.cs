using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	protected Vector3 localRotation;
	protected float cameraDistance = 10f;
	public float mouseSensitivity = 4f;
	public float orbitDampening = 10f;

	public float zoomSensitivity= 15.0f;
	public float zoomSpeed= 5.0f;
	public float zoomMin= 5.0f;
	public float zoomMax= 80.0f;

	private float zoom;

	public float dragSpeed = 0.2f;
	private Vector3 dragOrigin;

	void Start()
	{
		zoom = Camera.main.fieldOfView;
	}

	void Update() 
	{

		zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
		zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
	}

	void LateUpdate()
	{
		//zooming
		Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, zoom, Time.deltaTime * zoomSpeed);

		//rotating
		if (Input.GetMouseButton (2) && (Input.GetAxis ("Mouse X") != 0 || Input.GetAxis ("Mouse Y") != 0)) 
		{
			localRotation.x += Input.GetAxis ("Mouse X") * mouseSensitivity;
			localRotation.y -= Input.GetAxis ("Mouse Y") * mouseSensitivity;

			localRotation.y = Mathf.Clamp (localRotation.y, -45f, 45f);

			Quaternion QT = Quaternion.Euler (localRotation.y, localRotation.x, 0);
			transform.rotation = Quaternion.Lerp (transform.rotation, QT, Time.deltaTime * orbitDampening);
		}

		//click and drag
		if (Input.GetMouseButtonDown(1))
		{
			dragOrigin = Input.mousePosition;
			return;
		}

		if (!Input.GetMouseButton(1)) return;

		Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
		Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

		transform.Translate(move, Space.World);
	}

}
