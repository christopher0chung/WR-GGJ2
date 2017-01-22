using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    private int activeLevel;
    private bool win;
    private bool lose;

	void Start () {
        activeLevel = 5;
        loadActiveLevel();
	}

    public void setActiveLevel(int levelInc)
    {
        activeLevel += levelInc;
        if (activeLevel < 5)
            activeLevel = 5;
    }

    void loadActiveLevel()
    {
        SceneManager.LoadScene(activeLevel, LoadSceneMode.Additive);
        win = lose = false;
    }

    void Win ()
    {
        win = true;
        SceneManager.UnloadSceneAsync(activeLevel);
        SceneManager.LoadScene(2);
    }

    void Lose()
    {
        lose = true;
        SceneManager.UnloadSceneAsync(activeLevel);
        SceneManager.LoadScene(3);
    }
}
