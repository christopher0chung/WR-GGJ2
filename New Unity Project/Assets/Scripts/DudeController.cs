using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeController : MonoBehaviour {

    Transform head;

    public float accSpeed = 10;
    public float resist = 10;
    float resisForce;

    float angularVel;
    float angularAcc;

    WaveMaker wave;
    // Use this for initialization
    void Start() {
        wave = FindObjectOfType<WaveMaker>();
        head = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update() {

        angularAcc = transform.rotation.z * accSpeed;
        resisForce += (head.localRotation.z) * resist;
        resisForce = Mathf.Lerp(resisForce, 0, 0.05f);
        angularVel += angularAcc - resisForce;
        head.localRotation = Quaternion.Euler(0, 0, angularVel + transform.rotation.z * 0.2f);
        //if (angularVel > 30) angularVel = 30;
        //else if (angularVel < -30) angularVel = -30;
        transform.position = Vector3.Lerp(transform.position, wave.valuesMain[Mathf.FloorToInt(wave.pointNum / 4)], 0.5f) + Vector3.up * 2;
        transform.right = (wave.valuesMain[Mathf.FloorToInt(wave.pointNum / 4) + 1] - wave.valuesMain[Mathf.FloorToInt(wave.pointNum / 4) - 1]).normalized;
    }


}
