using UnityEngine;
using System.Collections;

public class BatteryPickup : MonoBehaviour {

	public Score score;

	private ParticleSystem particles;
	private SpriteRenderer renderer;
	private BoxCollider2D collider;
	private AudioSource source;


	// Use this for initialization
	void Start () {
		particles = GetComponentInChildren<ParticleSystem>();
		renderer = GetComponent<SpriteRenderer>();
		source = GetComponent<AudioSource>();
		collider = GetComponent<BoxCollider2D>();
		score = GameObject.Find("Score").GetComponent<Score>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			StartCoroutine(HandlePickup());
		}
	}

	IEnumerator HandlePickup()
	{
		particles.gameObject.SetActive(false);
		renderer.enabled = false;
		collider.enabled = false;
		score.score += 100;
		source.Play();
		yield return new WaitForSeconds(source.clip.length);
		Destroy(gameObject);
	}
}
