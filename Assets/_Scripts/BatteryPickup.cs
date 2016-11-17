using UnityEngine;
using System.Collections;

public class BatteryPickup : MonoBehaviour {

	public Score score;

	// Use this for initialization
	void Start () {
		score = GameObject.Find("Score").GetComponent<Score>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			score.score += 100;
			Destroy(gameObject);
		}
	}
}
