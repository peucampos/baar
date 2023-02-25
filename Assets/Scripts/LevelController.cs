using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public bool isPause = false;
    public static int remainingArrows;

    public void ContinueBtn()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);
    }

    public void Victory(GameObject victory)
    {
        victory.SetActive(true);
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
