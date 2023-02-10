using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public float speed = 1f;
    public float fallDistance = 12f;
    public Vector3 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > initialPosition.y + fallDistance)
            transform.position = initialPosition;
        else
            transform.Translate(speed * Time.deltaTime * Vector2.up);
    }
}
