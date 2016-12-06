using UnityEngine;
using System.Collections;

public class BossChase : MonoBehaviour {

	public GameObject explosionEffect;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.tag == "Player")
		{
			col.collider.GetComponent<PlayerHealth>().health = 0f;
		}
		else
		{
			Instantiate(explosionEffect, col.collider.transform.position, Quaternion.identity);
		}
	}
}
