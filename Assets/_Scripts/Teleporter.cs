using UnityEngine;
using System.Collections;
using System;


public class Teleporter : MonoBehaviour {

	public Teleporter exitTele;
	public AudioSource teleSound;




	// Use this for initialization
	void Start () {
		teleSound = GetComponent<AudioSource>();
	}
		
	
    void OnTriggerEnter2D(Collider2D col)
    {
		if(!col.gameObject.GetComponent<PlayerControl>().isTeleporting)
		{
			teleSound.Play();
			StartCoroutine(col.gameObject.GetComponent<PlayerControl>().Teleport());
			col.transform.position = exitTele.transform.position;

		}
        

    }
}
