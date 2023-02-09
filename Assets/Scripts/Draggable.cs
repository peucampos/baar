using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public Transform fixedArrow;
    public GameObject arrowPrefab;
    public float speed = 5f;
    public float bounds = 4f;

    public void ShootArrow()
    {
        GameObject newArrow = Instantiate(arrowPrefab);
        newArrow.transform.position = fixedArrow.position;
    }
}
