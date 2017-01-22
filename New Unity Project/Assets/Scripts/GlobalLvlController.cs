using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLvlController : MonoBehaviour {

	public GameObject[] spawnZones;
	private int x;


	// Use this for initialization
	void Start () {
		x = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnZones [x].GetComponent<HazardSpawner>().levelOver == true) {
			spawnZones [x].SetActive (false);
			x++;
			spawnZones [x].SetActive (true);
		}
	}
}
