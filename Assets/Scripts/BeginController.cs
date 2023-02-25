using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginController : MonoBehaviour
{
    private void Start()
    {
        LevelController.remainingArrows = 0;
    }
    public void ContinueBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
