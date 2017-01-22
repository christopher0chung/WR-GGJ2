using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    public static LevelLoader instance;
    private int activeLevel;
    private bool win;
    private bool lose;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        activeLevel = 5;
        loadActiveLevel();
    }

    public void setActiveLevel(int levelInc) {
        activeLevel += levelInc;
        if (activeLevel < 5)
            activeLevel = 5;
    }

    void loadActiveLevel() {
        SceneManager.LoadScene(activeLevel, LoadSceneMode.Additive);
        win = lose = false;
    }

    public IEnumerator Win() {
        win = true;
        SceneManager.UnloadSceneAsync(activeLevel);
        SceneManager.LoadScene(2);
        yield return new WaitForSeconds(4);
        setActiveLevel(1);
        loadActiveLevel();
    }

    public void Lose() {
        lose = true;
        SceneManager.UnloadSceneAsync(activeLevel);
        SceneManager.LoadScene(3);
    }
}
