using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsMaker : MonoBehaviour {

    public GameObject ring;

	// Use this for initialization
	void Start () {
		for (int i = 0; i <28; i++)
        {
            GameObject myRing = (GameObject) Instantiate(ring, new Vector3(-188 + (i * 13.5f), 0, -10), Quaternion.identity, transform);
            myRing.transform.localScale = new Vector3(200, 200, 200);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
