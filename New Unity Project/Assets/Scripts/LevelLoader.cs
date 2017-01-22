using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelLoader : MonoBehaviour {
    public static LevelLoader instance;
    private int activeLevel;
    private bool win;
    private bool lose;

    public SpriteRenderer background;
    public TextMesh text;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        background = GetComponentInChildren<SpriteRenderer>();
        text = GetComponentInChildren<TextMesh>();
        activeLevel = 5;
        loadActiveLevel();
    }

    public void setActiveLevel(int levelInc) {
        activeLevel += levelInc;
        if (activeLevel < 5)
            activeLevel = 5;
    }

    public void loadActiveLevel() {
        SceneManager.LoadScene(activeLevel, LoadSceneMode.Additive);
        win = lose = false;
    }

    public void Win() {
        win = true;
        //SceneManager.UnloadSceneAsync(activeLevel);
        //SceneManager.LoadScene(2,LoadSceneMode.Additive);
        DOTween.To(() => background.color, (p) => background.color = p, new Color(0, 0, 0, 1), 1);
        DOTween.To(() => text.color, (p) => text.color = p, new Color(text.color.r, text.color.g, text.color.b, 1), 1);
        DOTween.To(() => background.color, (p) => background.color = p, new Color(0, 0, 0, 0), 1).SetDelay(1);
        DOTween.To(() => text.color, (p) => text.color = p, new Color(text.color.r, text.color.g, text.color.b, 0), 1).SetDelay(1).OnPlay(() => text.text = "LEVEL " + (activeLevel - 4).ToString())
                                                                                                                                    .OnComplete(() => { setActiveLevel(1); loadActiveLevel(); });
    }

    public void Lose() {
        lose = true;
        DOTween.To(() => background.color, (p) => background.color = p, new Color(0, 0, 0, 1), 1);
        DOTween.To(() => text.color, (p) => text.color = p, new Color(text.color.r, text.color.g, text.color.b, 1), 1);
        DOTween.To(() => background.color, (p) => background.color = p, new Color(0, 0, 0, 0), 1).SetDelay(1);
        DOTween.To(() => text.color, (p) => text.color = p, new Color(text.color.r, text.color.g, text.color.b, 0), 1).SetDelay(1).OnComplete(() => {
            SceneManager.UnloadSceneAsync(activeLevel);
            SceneManager.LoadScene(3);
        });
    }
}
