using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	private bool gameOver;
	private bool restart;
	private int score;
	private int level;

	public Text scoreText;
	public Text levelText;
	public Text gameOverText;

	// Use this for initialization
	void Start () {
		score = 0;
		level = 1;

		UpdateScore ();
		UpdateLevel (level);
	}
	
	public void AddScore (int newScoreValue){  //adds new value to score and updates it.
		score += newScoreValue;
		UpdateScore ();
        if (score < 0)
        {
            GetComponent<WinScript>().playerDied = true;
        }
	}

	void UpdateScore(){  //updates score text.
		//if (score < 0) {
		//	score = 0;
		//}
		scoreText.text = "Score: " + score;
        GetComponent<WinScript>().score = score;
	}

	public void UpdateLevel(int i) {  //updates level text
		level = i;
		//levelText.text = "Network Layer: " + level;
	}

	public void GameOver(){ //extra function for game over.
		gameOverText.text = "Hack Failed!";
		gameOver = true;
	}
}
