using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    public float intensity;
    public Material mat;

    // Use this for initialization
    void Start() {
        StartCoroutine(SetIntensity());
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(1);
        }

    }


    IEnumerator SetIntensity() {
        float startSetTime = Time.time;
        float waitTime = Random.Range(1, 3f);
        while (Time.time - startSetTime < waitTime) {
            intensity = 0;
            yield return null;
        }
        float startReSetTime = Time.time;
        waitTime = Random.Range(1, 3f);
        while (Time.time - startReSetTime < waitTime) {
            intensity = Random.Range(-1.0f, 1.0f);
            yield return null;
        }
        StartCoroutine(SetIntensity());
    }

    public IEnumerator SetIntensityOnce() {
        float startSetTime = Time.time;
        float waitTime = Random.Range(1, 3f);
        while (Time.time - startSetTime < waitTime) {
            intensity = Random.Range(-1.0f, 1.0f);
            yield return null;
        }
        intensity = 0;
    }

    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if (intensity == 0) {
            Graphics.Blit(source, destination);
            return;
        }
        mat.SetFloat("_Intensity", intensity);
        Graphics.Blit(source, destination, mat);
    }
}
