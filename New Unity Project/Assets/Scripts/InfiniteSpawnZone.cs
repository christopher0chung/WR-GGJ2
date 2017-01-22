using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawnZone : MonoBehaviour {

	public GameObject[] listOfObjects;

	public float hazardDelayMin;
	public float hazardDelayMax;
	public float[] lanePositions;

	// Use this for initialization
	void Start () {

//		lanePositions[0] = -30;
//		lanePositions[1] = -15;
//		lanePositions[2] = 0;
//		lanePositions[3] = 15;
//		lanePositions[4] = 30;

	}
	
	// Update is called once per frame
	void Update () {

		while (IsInvoking ("Spawn") == false) {
			Invoke ("Spawn", Random.Range (hazardDelayMin, hazardDelayMax));
		}

	}

	void Spawn() {
		Instantiate (listOfObjects[Random.Range(0, listOfObjects.Length)], new Vector3(106f,lanePositions[Random.Range(0,5)],15), Quaternion.identity);
		Instantiate (listOfObjects[Random.Range(0, listOfObjects.Length)], new Vector3(106f,lanePositions[Random.Range(0,5)],15), Quaternion.identity);
		Instantiate (listOfObjects[Random.Range(0, listOfObjects.Length)], new Vector3(106f,lanePositions[Random.Range(0,5)],15), Quaternion.identity);
		Instantiate (listOfObjects[Random.Range(0, listOfObjects.Length)], new Vector3(106f,lanePositions[Random.Range(0,5)],15), Quaternion.identity);
		Instantiate (listOfObjects[Random.Range(0, listOfObjects.Length)], new Vector3(106f,lanePositions[Random.Range(0,5)],15), Quaternion.identity);
	}
}
