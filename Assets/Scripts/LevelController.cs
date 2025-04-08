using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class LevelController : MonoBehaviour
{
    public bool isPause = false;
    public static int remainingArrows;
    public static int arrowCount;
    public TMP_Text txtVictory;

    private TMP_Text txtLevel;
    private int buildIndex;
    
    private void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;

        txtLevel = GameObject.Find("Level").GetComponent<TMP_Text>();

        if (txtLevel != null)
            txtLevel.text = "Level " + buildIndex.ToString();

        SetVictoryText();
    }

    public void ContinueBtn()
    {
        if (buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(buildIndex + 1);
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

    private void SetVictoryText()
    {
        string[] arrVictory = new string[]
        {
            "Victory!\n\nLevel " + (buildIndex + 1) + " is a mess...", //1-2
            "Victory!\n\nLevel " + (buildIndex + 1) + " looks easy...", //2-3
            "Victory!\n\nLevel " + (buildIndex + 1) + " zig zags...", //3-4
            "Victory!\n\nLevel " + (buildIndex + 1) + " is lonely...", //4-5
            "Victory!\n\nLevel " + (buildIndex + 1) + " has three rounds...", //5-6
            "Victory!\n\nLevel " + (buildIndex + 1) + " has intruders...", //6-7
            "Victory!\n\nLevel " + (buildIndex + 1) + " is anoying...", //7-8
            "Victory!\n\nLevel " + (buildIndex + 1) + ", let it go...", //8-9
            "Victory!\n\nLevel " + (buildIndex + 1) + " is calculated...", //9-10
            "Victory!\n\nLevel " + (buildIndex + 1) + " has options...", //10-11
            "Victory!\n\nLevel " + (buildIndex + 1) + " is not ready...", //11-12
            
        };

        txtVictory.text = arrVictory[buildIndex - 1];
    }

}
