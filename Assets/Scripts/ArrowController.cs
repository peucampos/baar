using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowController : MonoBehaviour
{
    private float arrowEndX = 15f;
    private float arrowSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * arrowSpeed);

        if (transform.position.x > arrowEndX)            
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject.transform.parent.gameObject);
    }
}
