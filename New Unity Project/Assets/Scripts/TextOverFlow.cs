using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOverFlow : MonoBehaviour {

    Text text;

    // Use this for initialization
    void Start() {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        if (Time.frameCount % 5 == 0) {
            AddText();
        }
    }

    void AddText() {
        string addtext = Random.value > 0.5f ? "0" : "1";
        text.text = addtext + text.text;
        if (text.text.Length >= 60) {
            text.text = text.text.Substring(0, 59);
        }
    }
}
