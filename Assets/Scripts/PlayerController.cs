using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Movement
    private bool isDragActive = false;
    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private float fixedPosition = -8;
    private Draggable lastDragged;

    //Shooting
    private float lastShot = 0;
    private float shootCooldown = 0.5f;
    public Animator animator;
    private const string ANIM_HOLDING = "isHolding";

    //Game
    private LevelController currentLevel;
    private GameObject objArcher;
    public TMP_Text txtArrowCount;
    public GameObject objGameOver;
    public GameObject objVictory;
    public int minimumArrows;
    

    void Awake()
    {
        PlayerController[] controllers = FindObjectsByType<PlayerController>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        lastDragged = GameObject.FindGameObjectWithTag("Player").GetComponent<Draggable>();
        currentLevel = GetComponent<LevelController>();
        LevelController.arrowCount = LevelController.remainingArrows + minimumArrows;       
    }

    void Update()
    {
        txtArrowCount.text = LevelController.arrowCount.ToString();

        if (this.isActiveAndEnabled)
        {
            if (GameObject.FindGameObjectsWithTag("Target").Length == 0)
            {
                currentLevel.Victory(objVictory);
                LevelController.remainingArrows = LevelController.arrowCount;
            }
            else if (LevelController.arrowCount <= 0 && GameObject.FindGameObjectsWithTag("Arrow").Length == 0)
            {
                currentLevel.GameOver(objGameOver);
            }
            else
            {
                if (!isDragActive && lastDragged != null)
                {
                    float moveY = 0f;

                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                        moveY = 1f;
                    else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                        moveY = -1f;

                    if (moveY != 0f)
                    {
                        Vector2 newPosition = lastDragged.transform.position;
                        newPosition.y += moveY * lastDragged.speed * Time.deltaTime;

                        // Limita o movimento vertical dentro dos bounds
                        newPosition.y = Mathf.Clamp(newPosition.y, -lastDragged.bounds, lastDragged.bounds);

                        lastDragged.transform.position = newPosition;
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        InitDrag();
                        return;
                    }                    
                                        
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        Drop();
                        return;
                    }
                }

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

        }
    }

    void InitDrag()
    {
        isDragActive = true;
        if (lastDragged != null)
        {
            lastDragged.PrepareArrow();
            animator.SetBool(ANIM_HOLDING, true);
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
        if (LevelController.arrowCount > 0 && Time.fixedTime - shootCooldown > lastShot)
        {
            ConsumeArrow();
            lastDragged.ShootArrow();
            lastShot = Time.fixedTime;
            animator.SetBool(ANIM_HOLDING, false);
        }
        isDragActive = false;
    }

    private void ConsumeArrow()
    {
        LevelController.arrowCount--;
        txtArrowCount.text = LevelController.arrowCount.ToString();
    }
}
