using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveLineRender : MonoBehaviour {
    WaveMaker wave;
    LineRenderer line;
    LineRenderer leftLine;
    LineRenderer rightLine;
    // Use this for initialization
    void Start() {
        wave = FindObjectOfType<WaveMaker>();
        line = GetComponent<LineRenderer>();
        leftLine = transform.FindChild("leftLine").GetComponent<LineRenderer>();
        rightLine = transform.FindChild("rightLine").GetComponent<LineRenderer>();
        line.numPositions = wave.pointNum;
        leftLine.numPositions = wave.pointNum;
        rightLine.numPositions = wave.pointNum;
    }

    // Update is called once per frame
    void Update() {
        line.SetPositions(wave.valuesMain);
        leftLine.SetPositions(wave.valuesLeft);
        rightLine.SetPositions(wave.valuesRight);
    }
}
