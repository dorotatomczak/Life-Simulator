using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	[System.Serializable]
	public class RotationSettings
	{
		public float mouseSensitivity = 4.0f;
		public float orbitDampening = 10.0f;
		public float rotateMin = -45.0f;
		public float rotateMax = 45.0f;
	}

	[System.Serializable]
	public class ZoomSettings
	{
		public float zoomSensitivity= 15.0f;
		public float zoomSpeed= 5.0f;
		public float zoomMin= 5.0f;
		public float zoomMax= 80.0f;
	}

	[System.Serializable]
	public class DragSettings
	{
		public float dragSpeed = 0.2f;
	}

	Vector3 localRotation;
	float zoom;
	Vector3 dragOrigin;

	public RotationSettings rotationSettings = new RotationSettings ();
	public ZoomSettings zoomSettings = new ZoomSettings ();
	public DragSettings dragSetttings =  new DragSettings ();

	void Start()
	{
		zoom = Camera.main.fieldOfView;
	}

	void Update() 
	{
		zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSettings.zoomSensitivity;
		zoom = Mathf.Clamp(zoom, zoomSettings.zoomMin, zoomSettings.zoomMax);
	}

	void LateUpdate()
	{
		//zooming
		Camera.main.fieldOfView = Mathf.Lerp (Camera.main.fieldOfView, zoom, Time.deltaTime * zoomSettings.zoomSpeed);

		//rotating
		if (Input.GetMouseButton (2) && (Input.GetAxis ("Mouse X") != 0 || Input.GetAxis ("Mouse Y") != 0)) 
		{
			localRotation.x += Input.GetAxis ("Mouse X") * rotationSettings.mouseSensitivity;
			localRotation.y -= Input.GetAxis ("Mouse Y") * rotationSettings.mouseSensitivity;

			localRotation.y = Mathf.Clamp (localRotation.y, rotationSettings.rotateMin, rotationSettings.rotateMax);

			Quaternion QT = Quaternion.Euler (localRotation.y, localRotation.x, 0);
			transform.rotation = Quaternion.Lerp (transform.rotation, QT, Time.deltaTime * rotationSettings.orbitDampening);
		}

		//click and drag
		if (Input.GetMouseButtonDown(1))
		{
			dragOrigin = Input.mousePosition;
			return;
		}

		if (!Input.GetMouseButton(1)) return;

		Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
		Vector3 move = new Vector3(pos.x * dragSetttings.dragSpeed, 0, pos.y * dragSetttings.dragSpeed);

		transform.Translate(move, Space.World);
	}

}
