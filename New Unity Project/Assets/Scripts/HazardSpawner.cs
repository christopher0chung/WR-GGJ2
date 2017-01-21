using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour {

	public float hazardDelayMin;
	public float hazardDelayMax;
	private int index = 0;

	public GameObject[] hazards;

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
			index = 0;
		}
	}

	void SpawnHazard() {
		if (index < hazards.Length) {
			Instantiate (hazards [index], transform.position, Quaternion.identity);
		}
	}

}
