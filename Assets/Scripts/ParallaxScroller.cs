using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] private float speed = 1;

    public Camera cam;
    public float modifier;

    float width;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().size.x / 4f;
        cam = Camera.main;
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < startPosition.x - width)
        {
           transform.position = startPosition;
        }
    }
}
