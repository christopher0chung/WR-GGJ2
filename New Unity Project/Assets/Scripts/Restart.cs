using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

    public void RestartIt ()
        {
            GameObject.FindGameObjectWithTag("TextController").GetComponent<LevelLoader>().setActiveLevel(-10000);
        }
}
