using UnityEngine;
using System.Collections;

public class PlatformRotator : MonoBehaviour {

	public int rotationSpeed;
	private bool rotatingForward;

	// Use this for initialization
	void Start () {
		rotationSpeed = 50;
		rotatingForward = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.eulerAngles.z >= 150)
		{
			rotatingForward = false;
		}
		else if(transform.eulerAngles.z <= 30)
		{
			rotatingForward = true;
		}

		if(rotatingForward)
		{
			transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
		}
		else if(!rotatingForward)
		{
			transform.Rotate((Vector3.back * rotationSpeed * Time.deltaTime));
		}
	}
}
