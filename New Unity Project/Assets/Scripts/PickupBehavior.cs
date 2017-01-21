using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour {

	public float rotSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RotateMe ();
	}

	void RotateMe() {
		transform.Rotate (new Vector3 (15 * rotSpeed, 30* rotSpeed, 45* rotSpeed) * Time.deltaTime);
	}

}
