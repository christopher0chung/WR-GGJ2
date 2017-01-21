using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisualizers : MonoBehaviour {

    private GameObject myP;

	void Start () {
        Invoke("MakeVis", .1f);
	}

    void MakeVis()
    {
        myP = (GameObject)Resources.Load("PlayerElement");
        GameObject thisVE = Instantiate(myP, new Vector3(-50, 0, 0), Quaternion.identity, transform);
    }
}
