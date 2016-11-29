using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
	public int score = 0;					// The player's score.


	private PlayerControl playerControl;	// Reference to the player control script.
	private int previousScore = 0;			// The score in the previous frame.
	private Text scoreText;					// Text that holds the player's score


	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
		scoreText = GetComponent<Text>();
	}


	void Update ()
	{
		// Set the score text.
		scoreText.text = "Score: " + score;

		// If the score has changed...
		if(previousScore != score)
			// ... play a taunt.
			playerControl.StartCoroutine(playerControl.Taunt());

		// Set the previous score to this frame's score.
		previousScore = score;
	}

}
