using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMover : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x - speed, transform.position.y, 0.0f);
	}
}
