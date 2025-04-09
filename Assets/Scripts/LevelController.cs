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
            // Trial 1
            "Victory!\n\nLevel " + (buildIndex + 1) + " is easy...", 
            "Victory!\n\nLevel " + (buildIndex + 1) + " is less easy...", 
            "Victory!\n\nLevel " + (buildIndex + 1) + " is the sea...", 
            "Victory!\n\nLevel " + (buildIndex + 1) + " is a mess...",
            "Victory!\n\nLevel " + (buildIndex + 1) + " is a ball...", 
            "Victory!\n\nLevel " + (buildIndex + 1) + " is up...",
            "Victory!\n\nLevel " + (buildIndex + 1) + " is down...",
            "Victory!\n\nLevel " + (buildIndex + 1) + " is lonely...", 
            "Victory!\n\nLevel " + (buildIndex + 1) + " is surrounded...", 
            // Bonus
            "Victory!\n\nLevel " + (buildIndex + 1) + " a BONUS!", 
            // Trial 2
            "Victory!\n\nLevel " + (buildIndex + 1) + " has intruders...", 
            "Victory!\n\nLevel " + (buildIndex + 1) + " is anoying...", 
            "Victory!\n\nLevel " + (buildIndex + 1) + ", let it go...", 
            "Victory!\n\nLevel " + (buildIndex + 1) + " is calculated...", 
            "Victory!\n\nLevel " + (buildIndex + 1) + " has options...", 
            "Victory!\n\nLevel " + (buildIndex + 1) + " is not ready...", 
            
        };

        txtVictory.text = arrVictory[buildIndex - 1];
    }

}
