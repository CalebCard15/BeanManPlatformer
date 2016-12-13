using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossChase : MonoBehaviour {

	public GameObject explosionEffect;

	public GameObject massiveExplosion;
	public GameObject outsideBackground;


	public float moveSpeed = 5;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		print(col.tag); 
		if(col.tag == "Player")
		{
			Instantiate(explosionEffect, col.transform.position, Quaternion.identity);
			Destroy(col.gameObject);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}
		else if(col.tag == "BossExit")
		{
			Instantiate(massiveExplosion, outsideBackground.transform.position, Quaternion.identity);
			outsideBackground.SetActive(true);
			moveSpeed = 30;
		}
		else if(col.tag == "ground")
		{
			//do nothing
		}
		else
		{
			Instantiate(explosionEffect, col.transform.position, Quaternion.identity);
			Destroy(col.gameObject);
		}
	}
}
