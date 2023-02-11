using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int currentLevel;

    public void Victory(GameObject victory)
    {
        victory.gameObject.SetActive(true);
        StartCoroutine(ReloadLevel());
    }

    public void GameOver(GameObject gameOver)
    {
        gameOver.gameObject.SetActive(true);
        StartCoroutine(ReloadLevel());
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(currentLevel);
    }

}
