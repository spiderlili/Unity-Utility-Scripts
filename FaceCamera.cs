//a script to allow the prefab object(text label etc) to always face the camera perfectly

using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {

	public Camera m_camera;

	// Use this for initialization
	void Start () 
	{
	//find the camera automatically at the start
		if (m_camera == null)
		{
			m_camera = Camera.main;
		}
	}
	
	// Update is called once per frame 
	void Update () 
	{
		//forces the sprite to look in the same direction as the camera
		//takes a target vector(forward vector of the camera added to current position) and a world up vector(up vector of the camera)
		//make the ui text align with the camera on every frame like a billboard to camera at all times
		transform.LookAt(transform.position + m_camera.transform.rotation * Vector3.forward, m_camera.transform.rotation * Vector3.up);

	}
}
