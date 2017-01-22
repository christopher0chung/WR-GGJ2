using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour {

	private TextController textController;

    public delegate void PlayerHit();
    public static event PlayerHit onPlayerHit;

	public float powerUpDuration = 10;

	WaveMaker wave;

    public void PlayerHitEvent()
    {
        onPlayerHit();
    }

    public delegate void PlayerCollect();
    public static event PlayerCollect onPlayerCollect;

    public void PlayerCollectEvent()
    {
        onPlayerCollect();
    }

    void Start(){
		wave = FindObjectOfType<WaveMaker> ();
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
            PlayerHitEvent();
			print ("Lost Data");
			textController.AddScore (-10);
            Instantiate(Resources.Load("FirewallExplosion"), col.transform.position, Quaternion.identity);
            if (EventRegister.instance.OnHitObstacle != null) EventRegister.instance.OnHitObstacle.Invoke();
            Destroy(col.gameObject);
		}
		if (col.tag == "Pickup") {
            PlayerCollectEvent();
			print ("Gained Data");
			textController.AddScore (2);
			Instantiate(Resources.Load("CollectionExplosion"), col.transform.position, Quaternion.identity);
            if (EventRegister.instance.OnPickUp != null) EventRegister.instance.OnPickUp.Invoke();
            Destroy(col.gameObject);
		}

		if (col.tag == "PUStepWaveL") {
			wave.SquareWave (powerUpDuration,true,false);
		}
		if (col.tag == "PUStepWaveR") {
			wave.SquareWave (powerUpDuration,false,true);
		}
		if (col.tag == "PUSawWaveL") {
			wave.SawtoothWave (powerUpDuration,true,false);
		}
		if (col.tag == "PUSawWaveR") {
			wave.SawtoothWave (powerUpDuration,false,true);
		}
		if (col.tag == "PUTriangleL") {
			wave.TriangleWave (powerUpDuration,true,false);
		}
		if (col.tag == "PUTriangleR") {
			wave.TriangleWave (powerUpDuration,false,true);
		}

	}

}
