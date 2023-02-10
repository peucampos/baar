using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isDragActive = false;
    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private float fixedPosition = -8;
    private Draggable lastDragged;
    private float lastShot = 0;
    private float shootCooldown = 1;

    void Awake()
    {
        PlayerController[] controllers = FindObjectsOfType<PlayerController>();
        if (controllers.Length > 1 )
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isDragActive && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if (Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position;
        }
        else
            return;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    lastDragged = draggable;
                    InitDrag();
                }
            }
        }

    }

    void InitDrag()
    {
        isDragActive = true;
        if (lastDragged!= null)
        {
            lastDragged.PrepareArrow();
        }
    }

    void Drag()
    {
        lastDragged.transform.position = new Vector2(fixedPosition, worldPosition.y);
        lastDragged.PullArrow();

        if (lastDragged.transform.position.y > lastDragged.bounds)
            lastDragged.transform.position = new Vector2(lastDragged.transform.position.x, lastDragged.bounds);
        if (lastDragged.transform.position.y < -lastDragged.bounds)
            lastDragged.transform.position = new Vector2(lastDragged.transform.position.x, -lastDragged.bounds);
    }

    void Drop()
    {
        if (Time.fixedTime - shootCooldown > lastShot)
        {
            lastDragged.ShootArrow();
            lastShot = Time.fixedTime;
        }
        isDragActive = false;
    }
}
