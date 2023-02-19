using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonRed : MonoBehaviour
{
    public float baseSpeed = 1f;
    public float maxSpeed = 1f;
    private float lowerBound = -7f;
    private float upperBound = 5f;
    private float balloodSpeed;

    // Start is called before the first frame update
    void Start()
    {
        balloodSpeed = Random.Range(baseSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > upperBound)
            transform.position = new Vector2(transform.position.x, lowerBound);
        else
            transform.Translate(balloodSpeed * Time.deltaTime * Vector2.up);
    }
}
