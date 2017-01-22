using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour {

	public float hazardDelayMin;
	public float hazardDelayMax;
	private int index = 0;
	public float spawnSpeed;
	public int levelChoice;

	private GameObject[] hazards;

	public GameObject[] LevelOne;
	public GameObject[] LevelOneB;
	public GameObject[] LevelOneC;
	public GameObject[] LevelTwo;
	public GameObject[] LevelThree;
	public GameObject[] LevelInfinite;

	void Start() {
		if(levelChoice == 1) {
			hazards = LevelOne;
		}
		if(levelChoice == 2) {
			hazards = LevelOneB;
		}
		if(levelChoice == 3) {
			hazards = LevelOneC;
		}
		if(levelChoice == 4) {
			hazards = LevelTwo;
		}
		if (levelChoice == 99) {
			hazards = LevelInfinite;
		}
	}


	// Update is called once per frame
	void Update () {
		if (index < hazards.Length) {
			if (hazards [index] == null) {
				Debug.Log ("No Hazard Found.");
				//break;
			} else {

				while (IsInvoking ("SpawnHazard") == false) {
					Invoke ("SpawnHazard", Random.Range (hazardDelayMin, hazardDelayMax));
					index++;
				}
			}
		} else {  //this else causes blocks to spawn infinitely. Remove once end game state is created.
			//index = 0;
		}
	}

	void SpawnHazard() {
		if (index < hazards.Length) {
			hazards [index].GetComponent<SpawnMover> ().speed = spawnSpeed;
			Instantiate (hazards [index], transform.position, Quaternion.identity);

		}
	}

}
