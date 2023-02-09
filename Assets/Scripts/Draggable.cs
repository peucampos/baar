using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public Transform fixedArrow;
    private float fixedArrowOriginalPosX;
    public GameObject arrowPrefab;
    public float speed = 5f;
    public float bounds = 4f;

    private void Start()
    {
        fixedArrowOriginalPosX = fixedArrow.position.x;
    }

    internal void ShootArrow()
    {
        GameObject newArrow = Instantiate(arrowPrefab);
        newArrow.transform.position = fixedArrow.position;

    }

    internal void PullArrow()
    {
        if (fixedArrow.position.x > transform.position.x)
            fixedArrow.Translate(Time.deltaTime * Vector2.left);
    }

    internal void PrepareArrow()
    {
        fixedArrow.position = new Vector2(fixedArrowOriginalPosX, transform.position.y);
    }


}
