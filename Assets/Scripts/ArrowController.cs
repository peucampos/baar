using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowController : MonoBehaviour
{
    private float arrowEndX = 15f;
    private float arrowSpeed = 3f;
    public ParticleSystem explosionPrefab;
    public Vector3 explosionOffset = new Vector3(0f, 0.8f, 0f);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * arrowSpeed);

        if (transform.position.x > arrowEndX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Color balloonColor = ApplyEffect(collision.gameObject);
        ExplodeBalloon(collision.gameObject.transform, balloonColor);
        Destroy(collision.gameObject);
    }

    private Color ApplyEffect(GameObject gameObject)
    {
        BalloonController balloon = gameObject.GetComponent<BalloonController>();

        switch (balloon.color)
        {
            case BalloonController.enumColor.Red:
                break;
            case BalloonController.enumColor.Yellow:
                LevelController.arrowCount--;
                break;
            case BalloonController.enumColor.Blue:
                break;
            case BalloonController.enumColor.Green:
                LevelController.arrowCount += 2;
                break;
            case BalloonController.enumColor.Orange:
                break;
            case BalloonController.enumColor.Purple:
                break;
            default:
                break;
        }

        return gameObject.GetComponent<SpriteRenderer>().color;
    }

    private void ExplodeBalloon(Transform transform, Color balloonColor)
    {
        ParticleSystem explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position + explosionOffset;
        var psMain = explosion.main;
        psMain.startColor = balloonColor;
        explosion.Play();
        Destroy(explosion.gameObject, 2f);
    }
}
