using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedCleanup : MonoBehaviour {

    public float cleanupTime;

	// Use this for initialization
	void Start () {
        Invoke("Cleanup", cleanupTime);
	}
	
    void Cleanup ()
    {
        Destroy(this.gameObject);
    }
}
