using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour {

    public float levelDuration;

    private float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (timer >= levelDuration)
        {
            GameObject.FindGameObjectWithTag("TextController").GetComponent<WinScript>().timeIsUp = true;
        }

	}
}
