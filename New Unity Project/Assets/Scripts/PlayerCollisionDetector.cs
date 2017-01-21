using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour {

	private TextController textController;

	void Start(){
		GameObject textControllerObject = GameObject.FindWithTag ("TextController");
		if (textControllerObject != null) {
			textController = textControllerObject.GetComponent<TextController>();
		}
		if (textController == null) {
			Debug.Log ("Cannot find 'textController' script");
		}
	}


	void OnTriggerEnter (Collider col) {
		if (col.tag == "Hazard") {
			print ("Lost Data");
			textController.AddScore (-10);
            Instantiate(Resources.Load("FirewallExplosion"), col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
		}
		if (col.tag == "Pickup") {
			print ("Gained Data");
			textController.AddScore (10);
			Destroy (col.gameObject);
		}
	}

}
