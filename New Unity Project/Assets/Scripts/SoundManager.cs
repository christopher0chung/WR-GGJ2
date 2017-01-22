using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	public int mySceneNum;

	void Awake() {
		SceneManager.sceneLoaded += NewScene;
		DontDestroyOnLoad(this.gameObject);
	}

	void Start(){
		
	}

	void NewScene (Scene scene, LoadSceneMode mode)
	{
		mySceneNum = scene.buildIndex;
		Debug.Log ("This is scene #: " + scene.buildIndex);
	}

}
