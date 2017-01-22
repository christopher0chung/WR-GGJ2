using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetTitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
	}
	
}
