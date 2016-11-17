using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossTeleporter : MonoBehaviour {

	public Score score;					//Used to get a copy of the score

	public Text bossText;				//Used to show how much score you need to access the boss level


	// Use this for initialization
	void Start () {
		score = GameObject.Find("Score").GetComponent<Score>();
		bossText = GameObject.Find("BossText").GetComponent<Text>();

		//Getting the inital scale of the scoreBar
	}
	
	// Update is called once per frame
	void Update () {
		bossText.text = score.score + " /1500";
	}

	void GoToNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			if(score.score >= 1500)
			{
				GoToNextLevel();
			}
		}
	}


}
