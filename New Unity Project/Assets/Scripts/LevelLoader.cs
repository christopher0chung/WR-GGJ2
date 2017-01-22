using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
	}
}
