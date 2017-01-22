using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMoves : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {

        float newX = transform.localPosition.x - Time.fixedDeltaTime * 5;
        if (newX <= -189)
            newX += 378;
        transform.localPosition = new Vector3(newX, transform.localPosition.y, transform.localPosition.z);
	}
}
