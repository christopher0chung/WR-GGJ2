using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveLineRender : MonoBehaviour {
    WaveMaker wave;
    LineRenderer line;
    // Use this for initialization
    void Start() {
        wave = FindObjectOfType<WaveMaker>();
        line = GetComponent<LineRenderer>();
        line.numPositions = 100;
    }

    // Update is called once per frame
    void Update() {
        line.SetPositions(wave.valuesMain);
    }
}
