using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScript : MonoBehaviour {

	public bool sceneIsOver = false;
	public bool timeIsUp = false;
	public bool playerDied = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (timeIsUp == true) {
			if (score > 85) {
				//go to next stage
				//unload previous stage
			} else {
				//go to try again screen
			}
		}
	if (playerDied == true) {
			//go to try again screen
			
		}
	}

	}
		
}
