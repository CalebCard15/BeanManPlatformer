using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossExit : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		print("Get TRIGGERED");
		if(col.tag == "Player")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
			
	}
}
