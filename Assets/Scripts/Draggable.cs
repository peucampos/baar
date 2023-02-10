using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector2 fixedArrowPosition = new(-7.8f, 0.34f);
    private float fixedArrowOriginalPosX;
    public GameObject arrowPrefab;
    public float speed = 5f;
    public float bounds = 4f;

    private void Start()
    {
        fixedArrowOriginalPosX = fixedArrowPosition.x;
    }

    internal void ShootArrow()
    {
        GameObject newArrow = Instantiate(arrowPrefab);
        newArrow.transform.position = new Vector2(fixedArrowPosition.x, transform.position.y + fixedArrowPosition.y);

    }

    internal void PullArrow()
    {
        
    }

    internal void PrepareArrow()
    {
        
    }


}
