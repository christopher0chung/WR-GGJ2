using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	private int mySceneNum;

	public GameObject musicChild;
	public GameObject sfxChild;
	private AudioSource musicGenerator;
	private AudioSource sfxGenerator;

	//AUDIO TRACKS
	public AudioClip mainTheme;
	public AudioClip titleTheme;
	public AudioClip deadTheme;

	public float mainThemeVolume;
	public float titleThemeVolume;
	public float deadThemeVolume;


	//SFX TRACKS
	public AudioClip coinGrab;
	public AudioClip collisionOne;
	public AudioClip collisionTwo;
	

	void Awake() {
		SceneManager.sceneLoaded += NewScene;
		DontDestroyOnLoad(this.gameObject);

		musicGenerator = musicChild.GetComponent<AudioSource> ();
		sfxGenerator = sfxChild.GetComponent<AudioSource> ();

	}

	void NewScene (Scene scene, LoadSceneMode mode)
	{
		mySceneNum = scene.buildIndex;
		Debug.Log ("This is scene #: " + scene.buildIndex);


		//THIS IS THE TITLE SCREEN
		if (mySceneNum == 1) {
			musicGenerator.volume = titleThemeVolume;
			musicGenerator.clip = titleTheme;
			musicGenerator.Play ();
		}


		//LEVEL 1: PRESSING START LOADS SCENE 4 THEN 5 for some reason
		if (mySceneNum == 4) {
			musicGenerator.volume = mainThemeVolume;
			musicGenerator.clip = mainTheme;
			musicGenerator.Play ();
		}

		//DEAD SCREEN temporarily set to 7
		if (mySceneNum == 7) {
			musicGenerator.volume = deadThemeVolume;
			musicGenerator.clip = deadTheme;
			musicGenerator.Play ();
		}



	}

}
