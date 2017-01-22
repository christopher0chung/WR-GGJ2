using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOn : MonoBehaviour {

    public void MoveOnToNext ()
        {
            GameObject.FindGameObjectWithTag("TextController").GetComponent<LevelLoader>().setActiveLevel(1);
        }
}
