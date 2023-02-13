using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonRed : MonoBehaviour
{
    public float baseSpeed = 1f;
    public float maxSpeed = 1f;
    public float fallDistance = 12f;
    public Vector3 initialPosition;
    private float balloodSpeed;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        balloodSpeed = Random.Range(baseSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > initialPosition.y + fallDistance)
            transform.position = initialPosition;
        else
            transform.Translate(balloodSpeed * Time.deltaTime * Vector2.up);
    }
}
