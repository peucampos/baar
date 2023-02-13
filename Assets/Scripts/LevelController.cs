using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int currentLevel;
    public bool isVictory = false;
    public bool isPause = false;

    void Update()
    {
        if (isVictory && (Input.touchCount > 0 || Input.GetMouseButton(0)))
        {
            int nextLevel = currentLevel + 1;
            if (SceneManager.GetSceneAt(nextLevel) != null)
                SceneManager.LoadScene(nextLevel);
            else
                SceneManager.LoadScene(0);
        }
    }

    public void PauseBtn()
    {
        Time.timeScale = isPause ? 0 : 1;
        isPause = !isPause;
    }

    public void Victory(GameObject victory)
    {
        victory.SetActive(true);
        isVictory = true;
    }

    public void GameOver(GameObject gameOver)
    {
        gameOver.SetActive(true);
        StartCoroutine(ReloadLevel(0));
    }

    IEnumerator ReloadLevel(int level)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(level);
    }

}
