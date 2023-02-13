using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginController : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(1);
        }
    }
}
