using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossChase : MonoBehaviour {

	public GameObject explosionEffect;

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
		else
		{
			Instantiate(explosionEffect, col.transform.position, Quaternion.identity);
			Destroy(col.gameObject);
		}
	}
}
