using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour {

	public Camera cam;

	public Transform target1, target2;

	// movement parameters
	public float scrollSpeed = 1.0f;
	public float smoothSpeed = 0.125f;
	public float startOffset = 2.0f;

	public Vector3 offset;

	private float timeElapsed = 0.0f;

	private Vector3 lastAverage;

	// Bool to indicate whether the players have moved above a certain level
	private bool camStart;

    private void Start()
    {
        cam = GetComponent<Camera>();
        if(cam == null)
        {
            cam = Camera.main;
        }
		//cam.orthographic = true;
		//cam.orthographicSize = 6;
		camStart = false;
    }

	void LateUpdate () {
		SetCameraPosition ();
	}

	void SetCameraPosition() {
		if (camStart) {
			timeElapsed += Time.deltaTime * (scrollSpeed / 5.0f);
		}
			
		Vector3 averagePosition = (target1.position + target2.position)/2;

		if (!camStart) {
			if (averagePosition.y > startOffset) {
				camStart = true;
				GameObject.Find ("Canvas").GetComponent<UIController> ().FadeOut ();
			}
		}

		Vector3 desiredPosition = new Vector3(0, timeElapsed, transform.position.z) + offset;

		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition,  Time.deltaTime * smoothSpeed);

		transform.position = smoothedPosition;
	}
		
}
