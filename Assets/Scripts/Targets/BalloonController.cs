using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public float baseSpeed = 1f;
    public float maxSpeed = 1f;
    public float autoDestructionTime = 0f;

    private float lowerBound = -7f;
    private float upperBound = 5f;
    private float balloonSpeed;

    public enum enumColor
    {
        Red,
        Yellow,
        Blue,
        Green,
        Orange,
        Purple
    }
    public enumColor color;

    // Start is called before the first frame update
    void Start()
    {
        balloonSpeed = Random.Range(baseSpeed, maxSpeed);

        if (autoDestructionTime > 0)
            Destroy(gameObject, autoDestructionTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > upperBound)
            transform.position = new Vector2(transform.position.x, lowerBound);
        else
            transform.Translate(balloonSpeed * Time.deltaTime * Vector2.up);
    }
}
