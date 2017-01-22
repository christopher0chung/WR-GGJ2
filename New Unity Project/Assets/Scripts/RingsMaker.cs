using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsMaker : MonoBehaviour {

    public GameObject ring;
    public Material ringMat;

    private List<GameObject> rings = new List<GameObject>();

    // Use this for initialization
    void Start () {
		for (int i = 0; i <28; i++)
        {
            GameObject myRing = (GameObject) Instantiate(ring, new Vector3(-188 + (i * 13.5f), 0, -10), Quaternion.identity, transform);
            myRing.transform.localScale = new Vector3(200, 200, 200);
            rings.Add(myRing);
        }

        if (GameObject.Find("Avatar") != null)
        {
            PlayerCollisionDetector.onPlayerHit += PlayerHit;
            PlayerCollisionDetector.onPlayerCollect += PlayerCollect;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        ringMat.color = Color.Lerp(ringMat.color, new Color(.15625f, .355f, .406f), .2f);
        foreach (GameObject aRing in rings)
        {
            aRing.transform.localScale = Vector3.Lerp(aRing.transform.localScale, Vector3.one * 200, .2f);
        }
        
	}


    void PlayerHit()
    {
        foreach (GameObject aRing in rings)
        {
            aRing.transform.localScale = Vector3.one * 180;
        }
        ringMat.color = new Color (1, .371f, .344f);
    }

    void PlayerCollect()
    {
        foreach (GameObject aRing in rings)
        {
            aRing.transform.localScale = Vector3.one * 210;
        }
        ringMat.color = new Color(.074f, .781f, .539f);
    }

    public void unSubscribe()
    {
        PlayerCollisionDetector.onPlayerHit -= PlayerHit;
        PlayerCollisionDetector.onPlayerCollect -= PlayerCollect;
    }
}
