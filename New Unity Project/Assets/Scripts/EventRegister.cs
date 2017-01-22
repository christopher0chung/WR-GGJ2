using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using DG.Tweening;


public class EventRegister : MonoBehaviour {
    public static EventRegister instance;

    void Awake() {
        instance = this;
    }

    public delegate void NormalEventHandler();
    public NormalEventHandler OnPickUp;
    public NormalEventHandler OnHitObstacle;


    public void FishEyeInOut() {
        DOTween.To(() => Camera.main.GetComponent<Fisheye>().strengthX, (x) => Camera.main.GetComponent<Fisheye>().strengthX = x, 0.5f, 0.5f).SetDelay(0);
        DOTween.To(() => Camera.main.GetComponent<Fisheye>().strengthY, (x) => Camera.main.GetComponent<Fisheye>().strengthY = x, 0.5f, 0.5f).SetDelay(0);
        DOTween.To(() => Camera.main.GetComponent<Fisheye>().strengthX, (x) => Camera.main.GetComponent<Fisheye>().strengthX = x, 0, 0.5f).SetDelay(0.5f);
        DOTween.To(() => Camera.main.GetComponent<Fisheye>().strengthY, (x) => Camera.main.GetComponent<Fisheye>().strengthY = x, 0, 0.5f).SetDelay(0.5f);
    }

    void Fun() {

    }
}
