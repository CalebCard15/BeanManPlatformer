using UnityEngine;
using System.Collections;

public class BossBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Destroy the rocket after 5 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 5);
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			StartCoroutine(col.gameObject.GetComponent<PlayerShip>().HitPlayer());
			Destroy(gameObject);
		}

	}
}
