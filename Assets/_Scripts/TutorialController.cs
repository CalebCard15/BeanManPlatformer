using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {

	public Canvas childCanvas;
	public CanvasScaler canvasScaler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.tag == "Player")
		{
			childCanvas.enabled = true;
			canvasScaler.enabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			childCanvas.enabled = false;
			canvasScaler.enabled = false;
		}
	}
}
