using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		Debug.Log ("I've been hit!");
	}

}
