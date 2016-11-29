using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreShadow : MonoBehaviour
{
	public Text guiCopy;		// A copy of the score.
	public Text shadowText;		// The text for the drop shadow


	void Start()
	{
		guiCopy = GameObject.Find("Score").GetComponent<Text>();
		shadowText = GetComponent<Text>();

	}


	void Update ()
	{
		// Set the text to equal the copy's text.
		shadowText.text = guiCopy.text;
	}
}
