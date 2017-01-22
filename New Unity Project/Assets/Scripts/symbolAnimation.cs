using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class symbolAnimation : MonoBehaviour {

    public Sprite[] symbols;

    public float scaleAmount = 1;

    Vector3 originalScale;
    SpriteRenderer spriteRnd;

    public int AnimateSpeedDown = 1;

    // Use this for initialization
    void Start() {
        spriteRnd = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update() {
        transform.localScale = new Vector3(originalScale.x * (scaleAmount * Mathf.Sin(Time.time * 5) + 1), originalScale.y * (scaleAmount * Mathf.Cos(Time.time * 5) + 1), originalScale.z);
        if (Time.frameCount % AnimateSpeedDown == 0) spriteRnd.sprite = symbols[Random.Range(0, symbols.Length)];
    }
}
