using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScript : MonoBehaviour {

    public bool sceneIsOver = false;
    public bool timeIsUp = false;
    public bool playerDied = false;
    public int score = 0;
    LevelLoader loader;
    // Use this for initialization
    void Start() {
        loader = GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.X)) {
        }

        if (score > 0) {

        } else {
            //go to try again screen

        }
    }

}
