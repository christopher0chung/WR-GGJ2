using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	public int mySceneNum;
	public AudioSource musicGenerator;



	//AUDIO TRACKS
	public AudioClip mainTheme;
	public AudioClip titleTheme;
	public AudioClip deadTheme;

	void Awake() {
		SceneManager.sceneLoaded += NewScene;
		DontDestroyOnLoad(this.gameObject);

		musicGenerator = GetComponent<AudioSource> ();

	}

	void NewScene (Scene scene, LoadSceneMode mode)
	{
		mySceneNum = scene.buildIndex;
		Debug.Log ("This is scene #: " + scene.buildIndex);


		//THIS IS THE TITLE SCREEN
		if (mySceneNum == 1) {
			musicGenerator.volume = 1f;
			musicGenerator.clip = titleTheme;
		}


		//LEVEL 1: PRESSING START LOADS SCENE 4 THEN 5 for some reason
		if (mySceneNum == 4) {
			musicGenerator.volume = 0.1f;
			musicGenerator.clip = mainTheme;
		}



	}

}
