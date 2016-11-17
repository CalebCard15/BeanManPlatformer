using UnityEngine;
using System.Collections;
using System;


public class Teleporter : MonoBehaviour {

	public Teleporter exitTele;



	// Use this for initialization
	void Start () {

	}
		
	
    void OnTriggerEnter2D(Collider2D col)
    {
		if(!col.gameObject.GetComponent<PlayerControl>().isTeleporting)
		{
			StartCoroutine(col.gameObject.GetComponent<PlayerControl>().Teleport());
			col.transform.position = exitTele.transform.position;

		}
        

    }
}
