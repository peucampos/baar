using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Transform fixedArrow;
    public GameObject arrowPrefab;
    public float speed = 5f;

    private float bounds = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * joystick.Vertical * Time.deltaTime * Vector2.up);

        if (transform.position.y > bounds)
            transform.position = new Vector2(transform.position.x, bounds);
        if (transform.position.y < -bounds)
            transform.position = new Vector2(transform.position.x, -bounds);
    }

    public void ShootArrow()
    {
        GameObject newArrow = Instantiate(arrowPrefab);
        newArrow.transform.position = fixedArrow.position;
    }
}
